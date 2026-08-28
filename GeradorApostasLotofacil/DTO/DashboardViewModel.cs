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
        /// Últimos 10 jogos do usuário
        /// </summary>
        public List<DashboardJogoResumo> UltimosJogos { get; set; } = new();
    }

    public class DashboardJogoResumo
    {
        public int Id { get; set; }
        public DateTime DataAposta { get; set; }
        public DateTime? DataSorteio { get; set; }
        public List<int> Numeros { get; set; } = new();
        public int Acertos { get; set; }
    }
}
