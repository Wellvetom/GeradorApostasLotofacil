namespace GeradorApostasLotofacil.DTO
{
    public class DashboardViewModel
    {
        public int TotalApostas { get; set; }
        public int TotalJogos { get; set; }
        public DateTime? UltimaApostaData { get; set; }
        public decimal MelhorAcerto { get; set; }

        /// <summary>
        /// Percentual de jogos com 11+ acertos
        /// </summary>
        public decimal TaxaAcerto { get; set; }

        /// <summary>
        /// Número mais utilizado pelo usuário
        /// </summary>
        public int NumeroSorte { get; set; }

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

        /// <summary>
        /// Top 10 números com maior aderência para o próximo jogo, calculados a partir
        /// das apostas já conferidas e não premiadas (menos de 11 acertos).
        /// (Numero, Score de aderência)
        /// </summary>
        public List<(int Numero, int Score)> NumerosAderencia { get; set; } = new();

        /// <summary>
        /// Quantidade de jogos feitos por dia (ordenado por data crescente).
        /// (Dia, Quantidade de jogos)
        /// </summary>
        public List<(DateTime Dia, int Quantidade)> JogosPorDia { get; set; } = new();
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
