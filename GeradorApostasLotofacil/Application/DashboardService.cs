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

                        if (resultadoOficial != null)
                        {
                            var jogoResultado = resultadoOficial.Jogos.FirstOrDefault();
                            if (jogoResultado != null)
                            {
                                acertos = jogo.Numeros
                                    .Intersect(jogoResultado.Numeros)
                                    .Count();
                            }
                        }

                        if (acertos >= 11)
                        {
                            distribuicao.TryGetValue(acertos, out int count);
                            distribuicao[acertos] = count + 1;
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
