using GeradorApostasLotofacil.DTO;

namespace GeradorApostasLotofacil.Application
{
    public interface IConferenciaService
    {
        Task<List<ApostaResultadoViewModel>> ObterApostasComResultado(int usuarioId);
        List<(string Jogo, int Quantidade)> ObterJogosRepetidos();
    }
}
