using GeradorApostasLotofacil.Domain;

namespace GeradorApostasLotofacil.Application
{
    public interface IGeracaoService
    {
        ApostaModel GerarJogosInteligentes(decimal quantidadeJogos);
    }
}
