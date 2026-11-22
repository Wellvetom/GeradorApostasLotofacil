namespace GeradorApostasLotofacil.Domain
{
    /// <summary>
    /// Modalidade de loteria suportada pela aplicação.
    /// O valor é persistido na coluna Modalidade de <see cref="ApostaModel"/>
    /// para segregar apostas e sorteios oficiais por loteria.
    /// </summary>
    public enum Modalidade
    {
        /// <summary>Lotofácil: 25 números, 15 por jogo, prêmios a partir de 11 acertos.</summary>
        Lotofacil = 0,

        /// <summary>Mega Sena: 60 números, 6 por jogo, prêmios a partir de 4 acertos (quadra).</summary>
        MegaSena = 1
    }
}
