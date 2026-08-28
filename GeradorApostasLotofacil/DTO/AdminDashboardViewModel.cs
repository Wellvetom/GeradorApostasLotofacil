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

        /// <summary>
        /// Pares de sorteios com 12 números em comum
        /// </summary>
        public List<ParSorteioComum> ParesCom12 { get; set; } = new();

        /// <summary>
        /// Pares de sorteios com 13 números em comum
        /// </summary>
        public List<ParSorteioComum> ParesCom13 { get; set; } = new();

        /// <summary>
        /// Pares de sorteios com 14 números em comum
        /// </summary>
        public List<ParSorteioComum> ParesCom14 { get; set; } = new();

        // Mantidos para compatibilidade
        public int JogosComum12 => ParesCom12.Count;
        public int JogosComum13 => ParesCom13.Count;
        public int JogosComum14 => ParesCom14.Count;
    }

    public class AdminSorteioResumo
    {
        public int NuSorteio { get; set; }
        public DateTime? DataApuracao { get; set; }
        public List<int> Numeros { get; set; } = new();
    }

    public class ParSorteioComum
    {
        public int Sorteio1 { get; set; }
        public int Sorteio2 { get; set; }
        public int NumerosEmComum { get; set; }
        public string NumerosComuns { get; set; } = string.Empty;
    }
}
