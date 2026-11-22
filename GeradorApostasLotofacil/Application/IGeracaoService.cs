using GeradorApostasLotofacil.Domain;

namespace GeradorApostasLotofacil.Application
{
    public interface IGeracaoService
    {
        ApostaModel GerarJogosInteligentes(decimal quantidadeJogos, int qtdMaisSorteados = 12, int qtdMenosSorteados = 0);

        /// <summary>
        /// Gera UM jogo inédito (com a quantidade de números da modalidade) que, comparado aos
        /// sorteios oficiais importados, atinja pelo menos <paramref name="acertosAlvo"/> acertos
        /// em pelo menos <paramref name="minSorteios"/> sorteios distintos.
        /// </summary>
        /// <param name="acertosAlvo">Quantidade mínima de acertos por sorteio (faixas da modalidade).</param>
        /// <param name="minSorteios">Quantidade mínima de sorteios que devem atingir o alvo.</param>
        /// <returns>Lista com os números do jogo gerado (ordenados).</returns>
        List<int> GerarJogoComCriterio(int acertosAlvo, int minSorteios);
    }
}
