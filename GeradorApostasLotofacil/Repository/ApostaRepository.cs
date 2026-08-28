using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GeradorApostasLotofacil.Repository
{
    public class ApostaRepository : IApostaRepository
    {
        private readonly AppDbContext _context;

        public ApostaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Salvar(ApostaModel aposta)
        {
            _context.Apostas.Add(aposta);
            await _context.SaveChangesAsync();
        }

        public async Task<ApostaModel?> ObterUltima()
        {
            return await _context.Apostas
                .Where(x => x.UsuarioId == null && x.DataExclusao == null)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<ApostaModel>> ObterUltimas10()
        {
            return await _context.Apostas
                .Include(x => x.Jogos)
                .OrderByDescending(x => x.DataInclusao)
                .Take(10)
                .ToListAsync();
        }

        public List<(int Numero, int Quantidade)> ObterRankingNumeros()
        {
            var numeros = _context.Jogos.AsEnumerable();

            var retorno = numeros
                .SelectMany(j => j.Numeros)
                .GroupBy(n => n)
                .Select(g => (
                    Numero: g.Key,
                    Quantidade: g.Count()
                ))
                .OrderByDescending(x => x.Quantidade)
                .ToList();

            return retorno;
        }

        public async Task<List<ApostaModel>> ObterTodas()
        {
            return await _context.Apostas
                .Where(x => x.DataExclusao == null)
                .ToListAsync();
        }

        public async Task<List<ApostaModel>> ObterTodasPorId(int usuarioId)
        {
            return await _context.Apostas
                .Include(x => x.Jogos)
                .Where(x => x.UsuarioId == usuarioId && x.DataExclusao == null)
                .ToListAsync();
        }
    }
}
