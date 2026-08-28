namespace GeradorApostasLotofacil.DTO
{
    public class DashboardViewModel
    {
        public int TotalApostas { get; set; }
        public int TotalJogos { get; set; }
        public DateTime? UltimaApostaData { get; set; }
        public decimal MelhorAcerto { get; set; }

        /// <summary>
        /// Distribuição de acertos: chave = quantidade de acertos (11-15), valor = quantidade de jogos
        /// </summary>
        public Dictionary<int, int> DistribuicaoAcertos { get; set; } = new();

        /// <summary>
        /// Top 10 números mais utilizados pelo usuário (Numero, Frequência)
        /// </summary>
        public List<(int Numero, int Frequencia)> NumerosFrequentes { get; set; } = new();

        /// <summary>
        /// Últimas 5 apostas com data e quantidade de jogos
        /// </summary>
        public List<DashboardApostaResumo> UltimasApostas { get; set; } = new();
    }

    public class DashboardApostaResumo
    {
        public int Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataApuracao { get; set; }
        public int QuantidadeJogos { get; set; }
        public int MelhorAcerto { get; set; }
    }
}
