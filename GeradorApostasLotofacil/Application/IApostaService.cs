using GeradorApostasLotofacil.Domain;

namespace GeradorApostasLotofacil.Application
{
    public interface IApostaService
    {
        Task GravarApostas(ApostaModel aposta);
        Task<List<ApostaModel>> ListarApostas(int usuarioId);
        Task<List<ApostaModel>> ObterUltimas10();
        Task ExcluirAposta(int jogoId);
    }
}
