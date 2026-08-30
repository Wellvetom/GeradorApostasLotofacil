using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.DTO;
using GeradorApostasLotofacil.Helper;
using GeradorApostasLotofacil.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GeradorApostasLotofacil.Application
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context;

        public DashboardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardViewModel> ObterDashboard(int usuarioId)
        {
            try
            {
                // Apostas do usuário (ativas)
                var apostasUsuario = await _context.Apostas
                    .Where(a => a.UsuarioId == usuarioId && a.DataExclusao == null)
                    .Include(a => a.Jogos)
                    .OrderByDescending(a => a.DataInclusao)
                    .ToListAsync();

                // Resultados oficiais para comparação
                var resultadosOficiais = await _context.Apostas
                    .Where(a => a.UsuarioId == null)
                    .Include(a => a.Jogos)
                    .ToListAsync();

                var dashboard = new DashboardViewModel
                {
                    TotalApostas = apostasUsuario.Count,
                    TotalJogos = apostasUsuario.Sum(a => a.Jogos.Count),
                    UltimaApostaData = apostasUsuario.FirstOrDefault()?.DataInclusao
                };

                // Números mais frequentes do usuário
                var todosNumeros = apostasUsuario
                    .SelectMany(a => a.Jogos)
                    .SelectMany(j => j.Numeros)
                    .GroupBy(n => n)
                    .Select(g => (Numero: g.Key, Frequencia: g.Count()))
                    .OrderByDescending(x => x.Frequencia)
                    .Take(10)
                    .ToList();

                dashboard.NumerosFrequentes = todosNumeros;

                // Calcular acertos por jogo
                var distribuicao = new Dictionary<int, int>();
                int melhorAcertoGeral = 0;
                var ultimosJogosList = new List<DashboardJogoResumo>();

                // Acumuladores de aderência (apenas jogos não premiados, < 11 acertos)
                // Peso maior para números sorteados que o usuário deixou de fora ("oportunidade perdida")
                const int PESO_ACERTOU = 2;   // número que o usuário jogou e saiu no sorteio
                const int PESO_PERDEU = 3;    // número que saiu no sorteio mas o usuário não jogou
                var aderenciaScore = new Dictionary<int, int>();

                foreach (var aposta in apostasUsuario)
                {
                    var resultadoOficial = resultadosOficiais
                        .FirstOrDefault(r =>
                            r.DataApuracao.HasValue &&
                            aposta.DataApuracao.HasValue &&
                            r.DataApuracao.Value.Date == aposta.DataApuracao.Value.Date);

                    foreach (var jogo in aposta.Jogos)
                    {
                        int acertos = 0;
                        List<int>? numerosResultado = null;

                        if (resultadoOficial != null)
                        {
                            var jogoResultado = resultadoOficial.Jogos.FirstOrDefault();
                            if (jogoResultado != null)
                            {
                                numerosResultado = jogoResultado.Numeros;
                                acertos = jogo.Numeros
                                    .Intersect(numerosResultado)
                                    .Count();
                            }
                        }

                        if (acertos >= 11)
                        {
                            distribuicao.TryGetValue(acertos, out int count);
                            distribuicao[acertos] = count + 1;
                        }
                        else if (numerosResultado != null)
                        {
                            // Jogo conferido e NÃO premiado: alimenta o score de aderência
                            foreach (var numeroSorteado in numerosResultado)
                            {
                                int peso = jogo.Numeros.Contains(numeroSorteado)
                                    ? PESO_ACERTOU
                                    : PESO_PERDEU;

                                aderenciaScore.TryGetValue(numeroSorteado, out int atual);
                                aderenciaScore[numeroSorteado] = atual + peso;
                            }
                        }

                        if (acertos > melhorAcertoGeral)
                            melhorAcertoGeral = acertos;

                        // Coleta jogos para lista dos últimos 10
                        ultimosJogosList.Add(new DashboardJogoResumo
                        {
                            Id = jogo.Id,
                            DataAposta = aposta.DataInclusao,
                            DataSorteio = aposta.DataApuracao,
                            Numeros = jogo.Numeros,
                            Acertos = acertos
                        });
                    }
                }

                // Top 10 números com maior aderência para o próximo jogo
                dashboard.NumerosAderencia = aderenciaScore
                    .Select(kv => (Numero: kv.Key, Score: kv.Value))
                    .OrderByDescending(x => x.Score)
                    .ThenBy(x => x.Numero)
                    .Take(10)
                    .ToList();


                // Últimos 10 jogos (já estão ordenados por data decrescente da aposta)
                dashboard.UltimosJogos = ultimosJogosList.Take(10).ToList();

                dashboard.DistribuicaoAcertos = distribuicao;
                dashboard.MelhorAcerto = melhorAcertoGeral;

                // Taxa de acerto: percentual de jogos com 11+ acertos
                int totalJogosConferidos = ultimosJogosList.Count;
                int jogosComAcerto = distribuicao.Values.Sum();
                dashboard.TaxaAcerto = totalJogosConferidos > 0
                    ? (decimal)jogosComAcerto / totalJogosConferidos * 100
                    : 0;

                // Número da sorte: número mais usado pelo usuário
                dashboard.NumeroSorte = todosNumeros.Count > 0 ? todosNumeros[0].Numero : 0;

                return dashboard;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
