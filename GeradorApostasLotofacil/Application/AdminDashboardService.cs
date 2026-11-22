using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.DTO;
using GeradorApostasLotofacil.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GeradorApostasLotofacil.Application
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly AppDbContext _context;
        private readonly LoteriaConfig _config;

        public AdminDashboardService(AppDbContext context, LoteriaConfig config)
        {
            _context = context;
            _config = config;
        }

        public async Task<AdminDashboardViewModel> ObterDashboardAdmin()
        {
            // Apenas apostas importadas (sem usuário = oficiais) da modalidade
            var apostasImportadas = await _context.Apostas
                .Where(a => a.UsuarioId == null && a.DataExclusao == null && a.Modalidade == _config.Modalidade)
                .Include(a => a.Jogos)
                .OrderByDescending(a => a.NuSorteio)
                .ToListAsync();

            var dashboard = new AdminDashboardViewModel
            {
                TotalSorteiosImportados = apostasImportadas.Count,
                UltimoSorteioNumero = apostasImportadas.FirstOrDefault()?.NuSorteio ?? 0,
                DataUltimoSorteio = apostasImportadas.FirstOrDefault()?.DataApuracao
            };

            // Todos os números de todos os sorteios oficiais
            var todosNumeros = apostasImportadas
                .SelectMany(a => a.Jogos)
                .SelectMany(j => j.Numeros)
                .GroupBy(n => n)
                .Select(g => (Numero: g.Key, Frequencia: g.Count()))
                .OrderByDescending(x => x.Frequencia)
                .ToList();

            // Top 15 que mais saíram
            dashboard.NumerosQueMaisSairam = todosNumeros.Take(15).ToList();

            // Top 15 que menos saíram
            dashboard.NumerosQueMenosSairam = todosNumeros
                .OrderBy(x => x.Frequencia)
                .Take(15)
                .ToList();

            // Últimos 10 sorteios
            dashboard.UltimosSorteios = apostasImportadas
                .Take(10)
                .Select(a => new AdminSorteioResumo
                {
                    NuSorteio = a.NuSorteio,
                    DataApuracao = a.DataApuracao,
                    Numeros = a.Jogos.FirstOrDefault()?.Numeros ?? new List<int>()
                })
                .ToList();

            // Jogos repetidos (todos os números iguais)
            var todosJogos = apostasImportadas
                .SelectMany(a => a.Jogos.Select(j => new
                {
                    Numeros = j.Numeros.OrderBy(n => n).ToList(),
                    NuSorteio = a.NuSorteio
                }))
                .ToList();

            var hashes = todosJogos
                .Select(j => string.Join("-", j.Numeros.Select(n => n.ToString("D2"))))
                .GroupBy(h => h)
                .Count(g => g.Count() > 1);

            dashboard.JogosRepetidos = hashes;

            // Pares de sorteios com interseção dentro das faixas rastreadas pela modalidade.
            // Lotofácil: 12,13,14. Mega Sena: 3,4,5. (A faixa máxima = jogo idêntico é ignorada.)
            var faixas = _config.FaixasParesComuns;
            foreach (var faixa in faixas)
                dashboard.ParesPorComum[faixa] = new List<ParSorteioComum>();

            if (faixas.Count > 0)
            {
                int faixaMin = faixas.Min();
                int faixaMax = faixas.Max();

                for (int i = 0; i < todosJogos.Count; i++)
                {
                    for (int j = i + 1; j < todosJogos.Count; j++)
                    {
                        var comuns = todosJogos[i].Numeros.Intersect(todosJogos[j].Numeros).ToList();
                        int intersecao = comuns.Count;

                        if (intersecao >= faixaMin && intersecao <= faixaMax &&
                            dashboard.ParesPorComum.TryGetValue(intersecao, out var lista))
                        {
                            lista.Add(new ParSorteioComum
                            {
                                Sorteio1 = todosJogos[i].NuSorteio,
                                Sorteio2 = todosJogos[j].NuSorteio,
                                NumerosEmComum = intersecao,
                                NumerosComuns = string.Join(", ", comuns.OrderBy(n => n).Select(n => n.ToString("D2")))
                            });
                        }
                    }
                }
            }

            return dashboard;
        }
    }
}
