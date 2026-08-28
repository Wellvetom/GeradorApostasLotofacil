using GeradorApostasLotofacil.DTO;
using GeradorApostasLotofacil.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GeradorApostasLotofacil.Application
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly AppDbContext _context;

        public AdminDashboardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AdminDashboardViewModel> ObterDashboardAdmin()
        {
            // Apenas apostas importadas (sem usuário = oficiais)
            var apostasImportadas = await _context.Apostas
                .Where(a => a.UsuarioId == null && a.DataExclusao == null)
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

            // Jogos repetidos (15 números iguais)
            var todosJogos = apostasImportadas
                .SelectMany(a => a.Jogos)
                .Select(j => new { Numeros = j.Numeros.OrderBy(n => n).ToList(), NuSorteio = apostasImportadas.First(ap => ap.Jogos.Contains(j)).NuSorteio })
                .ToList();

            var hashes = todosJogos
                .Select(j => string.Join("-", j.Numeros.Select(n => n.ToString("D2"))))
                .GroupBy(h => h)
                .Count(g => g.Count() > 1);

            dashboard.JogosRepetidos = hashes;

            // Jogos com 12, 13 e 14 números em comum
            var paresCom12 = new List<ParSorteioComum>();
            var paresCom13 = new List<ParSorteioComum>();
            var paresCom14 = new List<ParSorteioComum>();

            for (int i = 0; i < todosJogos.Count; i++)
            {
                for (int j = i + 1; j < todosJogos.Count; j++)
                {
                    var comuns = todosJogos[i].Numeros.Intersect(todosJogos[j].Numeros).ToList();
                    int intersecao = comuns.Count;

                    if (intersecao >= 12 && intersecao < 15)
                    {
                        var par = new ParSorteioComum
                        {
                            Sorteio1 = todosJogos[i].NuSorteio,
                            Sorteio2 = todosJogos[j].NuSorteio,
                            NumerosEmComum = intersecao,
                            NumerosComuns = string.Join(", ", comuns.OrderBy(n => n).Select(n => n.ToString("D2")))
                        };

                        if (intersecao == 12) paresCom12.Add(par);
                        else if (intersecao == 13) paresCom13.Add(par);
                        else if (intersecao == 14) paresCom14.Add(par);
                    }
                }
            }

            dashboard.ParesCom12 = paresCom12;
            dashboard.ParesCom13 = paresCom13;
            dashboard.ParesCom14 = paresCom14;

            return dashboard;
        }
    }
}
