namespace GeradorApostasLotofacil.DTO
{
    public class AdminDashboardViewModel
    {
        public int TotalSorteiosImportados { get; set; }
        public int UltimoSorteioNumero { get; set; }
        public DateTime? DataUltimoSorteio { get; set; }

        /// <summary>
        /// Top números mais sorteados (oficiais)
        /// </summary>
        public List<(int Numero, int Frequencia)> NumerosQueMaisSairam { get; set; } = new();

        /// <summary>
        /// Top números que menos saíram (oficiais)
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
        /// Pares de sorteios agrupados por quantidade de números em comum.
        /// Chave = quantidade de números em comum (dependente da modalidade).
        /// </summary>
        public Dictionary<int, List<ParSorteioComum>> ParesPorComum { get; set; } = new();

        /// <summary>Obtém os pares de uma faixa de interseção (vazia se não houver).</summary>
        public List<ParSorteioComum> ObterPares(int comum) =>
            ParesPorComum.TryGetValue(comum, out var lista) ? lista : new List<ParSorteioComum>();

        // ---- Compatibilidade com a tela da Lotofácil (faixas fixas 12/13/14) ----
        public List<ParSorteioComum> ParesCom12 => ObterPares(12);
        public List<ParSorteioComum> ParesCom13 => ObterPares(13);
        public List<ParSorteioComum> ParesCom14 => ObterPares(14);

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
