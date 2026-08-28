using GeradorApostasLotofacil.Domain;

namespace GeradorApostasLotofacil.Repository
{
    public interface IApostaRepository
    {
        Task Salvar(ApostaModel aposta);
        Task<List<ApostaModel>> ObterTodas();
        Task<List<ApostaModel>> ObterUltimas10();
        Task<ApostaModel?> ObterUltima();
        Task<List<ApostaModel>> ObterTodasPorId(int usuarioId);
        List<(int Numero, int Quantidade)> ObterRankingNumeros();
    }
}
