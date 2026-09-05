using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Helper;
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

        public async Task<bool> ExisteApostaDuplicada(int usuarioId, DateTime? dataApuracao, List<List<int>> jogos)
        {
            // Assinatura do lote atual: conjunto (sem ordem) dos hashes de cada jogo.
            var assinaturaNova = jogos
                .Select(j => JogoHelper.GerarHashJogo(j))
                .OrderBy(h => h)
                .ToList();

            // Apostas ativas do mesmo usuário para o mesmo sorteio (mesma data de apuração).
            var query = _context.Apostas
                .Where(a => a.UsuarioId == usuarioId && a.DataExclusao == null);

            query = dataApuracao.HasValue
                ? query.Where(a => a.DataApuracao == dataApuracao)
                : query.Where(a => a.DataApuracao == null);

            var candidatas = await query
                .Include(a => a.Jogos)
                .ToListAsync();

            foreach (var aposta in candidatas)
            {
                var assinaturaExistente = aposta.Jogos
                    .Select(j => JogoHelper.GerarHashJogo(j.Numeros))
                    .OrderBy(h => h)
                    .ToList();

                // Mesmo conjunto de jogos (mesma quantidade e mesmos hashes) = duplicata.
                if (assinaturaExistente.SequenceEqual(assinaturaNova))
                    return true;
            }

            return false;
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

        public async Task ExcluirAposta(int jogoId)
        {
            var jogo = await _context.Jogos
                .Include(j => j.Aposta)
                .FirstOrDefaultAsync(j => j.Id == jogoId);

            if (jogo?.Aposta != null)
            {
                jogo.Aposta.DataExclusao = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
    }
}
