using GeradorApostasLotofacil.Domain;

namespace GeradorApostasLotofacil.Application
{
    public interface IApostaService
    {
        Task GravarApostas(ApostaModel aposta);
        Task<bool> ExisteApostaDuplicada(int usuarioId, DateTime? dataApuracao, List<List<int>> jogos);
        Task<List<ApostaModel>> ListarApostas(int usuarioId);
        Task<List<ApostaModel>> ObterUltimas10();
        Task ExcluirAposta(int jogoId);
    }
}
