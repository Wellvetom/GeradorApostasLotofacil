using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Repository;

namespace GeradorApostasLotofacil.Application
{
    public class ApostaService : IApostaService
    {
        private readonly IApostaRepository _repo;

        public ApostaService(IApostaRepository repo)
        {
            _repo = repo;
        }

        public async Task GravarApostas(ApostaModel aposta)
        {
            await _repo.Salvar(aposta);
        }

        public async Task<List<ApostaModel>> ListarApostas(int usuarioId)
        {
            return await _repo.ObterTodasPorId(usuarioId);
        }

        public async Task<List<ApostaModel>> ObterUltimas10()
        {
            return await _repo.ObterUltimas10();
        }

        public async Task ExcluirAposta(int jogoId)
        {
            await _repo.ExcluirAposta(jogoId);
        }
    }
}
