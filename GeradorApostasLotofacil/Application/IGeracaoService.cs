using GeradorApostasLotofacil.Domain;

namespace GeradorApostasLotofacil.Application
{
    public interface IGeracaoService
    {
        ApostaModel GerarJogosInteligentes(decimal quantidadeJogos, int qtdMaisSorteados = 12, int qtdMenosSorteados = 0);
    }
}
