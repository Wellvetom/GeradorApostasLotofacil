using GeradorApostasLotofacil.Domain;

namespace GeradorApostasLotofacil.Repository
{
    public interface IApostaRepository
    {
        Task Salvar(ApostaModel aposta);
        Task<bool> ExisteApostaDuplicada(int usuarioId, DateTime? dataApuracao, List<List<int>> jogos, Modalidade modalidade);
        Task<List<ApostaModel>> ObterTodas(Modalidade modalidade);
        Task<List<ApostaModel>> ObterUltimas10(Modalidade modalidade);
        Task<ApostaModel?> ObterUltima(Modalidade modalidade);
        Task<List<ApostaModel>> ObterTodasPorId(int usuarioId, Modalidade modalidade);
        List<(int Numero, int Quantidade)> ObterRankingNumeros(Modalidade modalidade);
        Task ExcluirAposta(int jogoId);
    }
}
