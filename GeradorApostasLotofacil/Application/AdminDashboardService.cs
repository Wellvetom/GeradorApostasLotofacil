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

            // Jogos repetidos
            var hashes = apostasImportadas
                .SelectMany(a => a.Jogos)
                .Select(j => string.Join("-", j.Numeros.OrderBy(n => n).Select(n => n.ToString("D2"))))
                .GroupBy(h => h)
                .Count(g => g.Count() > 1);

            dashboard.JogosRepetidos = hashes;

            return dashboard;
        }
    }
}
