using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Repository;

namespace GeradorApostasLotofacil.Application
{
    public class ApostaService : IApostaService
    {
        private readonly IApostaRepository _repo;
        private readonly LoteriaConfig _config;

        public ApostaService(IApostaRepository repo, LoteriaConfig config)
        {
            _repo = repo;
            _config = config;
        }

        public async Task GravarApostas(ApostaModel aposta)
        {
            // Garante que a aposta seja gravada com a modalidade desta vertente.
            aposta.Modalidade = _config.Modalidade;
            await _repo.Salvar(aposta);
        }

        public async Task<bool> ExisteApostaDuplicada(int usuarioId, DateTime? dataApuracao, List<List<int>> jogos)
        {
            return await _repo.ExisteApostaDuplicada(usuarioId, dataApuracao, jogos, _config.Modalidade);
        }

        public async Task<List<ApostaModel>> ListarApostas(int usuarioId)
        {
            return await _repo.ObterTodasPorId(usuarioId, _config.Modalidade);
        }

        public async Task<List<ApostaModel>> ObterUltimas10()
        {
            return await _repo.ObterUltimas10(_config.Modalidade);
        }

        public async Task ExcluirAposta(int jogoId)
        {
            await _repo.ExcluirAposta(jogoId);
        }
    }
}
