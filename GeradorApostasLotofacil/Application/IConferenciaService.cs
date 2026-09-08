using GeradorApostasLotofacil.DTO;

namespace GeradorApostasLotofacil.Application
{
    public interface IConferenciaService
    {
        Task<List<ApostaResultadoViewModel>> ObterApostasComResultado(int usuarioId);
        Task<VerificacaoApostaViewModel> VerificarAposta(int usuarioId, List<int> numeros);
        List<(string Jogo, int Quantidade)> ObterJogosRepetidos();
    }
}
