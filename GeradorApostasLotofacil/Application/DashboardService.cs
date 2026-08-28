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

                foreach (var aposta in apostasUsuario)
                {
                    var resultadoOficial = resultadosOficiais
                        .FirstOrDefault(r =>
                            r.DataApuracao.HasValue &&
                            aposta.DataApuracao.HasValue &&
                            r.DataApuracao.Value.Date == aposta.DataApuracao.Value.Date);

                    int melhorAcertoAposta = 0;

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

                        if (acertos > melhorAcertoAposta)
                            melhorAcertoAposta = acertos;

                        if (acertos > melhorAcertoGeral)
                            melhorAcertoGeral = acertos;
                    }

                    // Últimas 5 apostas
                    if (dashboard.UltimasApostas.Count < 5)
                    {
                        dashboard.UltimasApostas.Add(new DashboardApostaResumo
                        {
                            Id = aposta.Id,
                            DataInclusao = aposta.DataInclusao,
                            DataApuracao = aposta.DataApuracao,
                            QuantidadeJogos = aposta.Jogos.Count,
                            MelhorAcerto = melhorAcertoAposta
                        });
                    }
                }

                dashboard.DistribuicaoAcertos = distribuicao;
                dashboard.MelhorAcerto = melhorAcertoGeral;

                return dashboard;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
