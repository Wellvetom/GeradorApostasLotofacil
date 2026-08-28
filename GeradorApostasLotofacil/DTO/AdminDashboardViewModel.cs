namespace GeradorApostasLotofacil.DTO
{
    public class AdminDashboardViewModel
    {
        public int TotalSorteiosImportados { get; set; }
        public int UltimoSorteioNumero { get; set; }
        public DateTime? DataUltimoSorteio { get; set; }

        /// <summary>
        /// Top 15 números mais sorteados (oficiais)
        /// </summary>
        public List<(int Numero, int Frequencia)> NumerosQueMaisSairam { get; set; } = new();

        /// <summary>
        /// Top 15 números que menos saíram (oficiais)
        /// </summary>
        public List<(int Numero, int Frequencia)> NumerosQueMenosSairam { get; set; } = new();

        /// <summary>
        /// Últimos 10 sorteios importados
        /// </summary>
        public List<AdminSorteioResumo> UltimosSorteios { get; set; } = new();

        /// <summary>
        /// Jogos repetidos encontrados nos resultados oficiais
        /// </summary>
        public int JogosRepetidos { get; set; }
    }

    public class AdminSorteioResumo
    {
        public int NuSorteio { get; set; }
        public DateTime? DataApuracao { get; set; }
        public List<int> Numeros { get; set; } = new();
    }
}
