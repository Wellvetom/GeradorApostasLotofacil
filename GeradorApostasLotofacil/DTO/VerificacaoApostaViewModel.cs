namespace GeradorApostasLotofacil.DTO
{
    /// <summary>
    /// Resultado da verificação de uma aposta (15 números) informada pelo usuário.
    /// Indica se o usuário já apostou esses números e se eles já foram sorteados
    /// oficialmente com 15, 14, 13 ou 12 acertos.
    /// </summary>
    public class VerificacaoApostaViewModel
    {
        /// <summary>Números informados para verificação (ordenados).</summary>
        public List<int> Numeros { get; set; } = new();

        /// <summary>Indica se o usuário já apostou exatamente esses 15 números.</summary>
        public bool JaApostou => ApostasDoUsuario.Count > 0;

        /// <summary>
        /// Ocorrências dessa aposta feitas pelo próprio usuário (data de inclusão e do sorteio).
        /// </summary>
        public List<ApostaUsuarioResumo> ApostasDoUsuario { get; set; } = new();

        /// <summary>
        /// Sorteios oficiais em que esses números tiveram interseção com o resultado,
        /// agrupados por quantidade de acertos (15, 14, 13, 12).
        /// </summary>
        public List<SorteioAcertoResumo> Sorteios15 { get; set; } = new();
        public List<SorteioAcertoResumo> Sorteios14 { get; set; } = new();
        public List<SorteioAcertoResumo> Sorteios13 { get; set; } = new();
        public List<SorteioAcertoResumo> Sorteios12 { get; set; } = new();

        /// <summary>Indica se houve algum sorteio oficial com 12+ acertos.</summary>
        public bool JaFoiSorteado =>
            Sorteios15.Count > 0 || Sorteios14.Count > 0 ||
            Sorteios13.Count > 0 || Sorteios12.Count > 0;

        /// <summary>
        /// Maior quantidade de acertos obtida entre todos os sorteios oficiais
        /// (mesmo abaixo de 12). -1 quando não há sorteios oficiais para comparar.
        /// </summary>
        public int MelhorAcerto { get; set; } = -1;

        /// <summary>Concurso do sorteio em que ocorreu o melhor acerto (0 se indefinido).</summary>
        public int MelhorConcurso { get; set; }

        /// <summary>Data de apuração do sorteio em que ocorreu o melhor acerto.</summary>
        public DateTime? MelhorData { get; set; }

        /// <summary>
        /// Quantos dos números selecionados NÃO foram sorteados no melhor resultado.
        /// Corresponde a (15 - MelhorAcerto). -1 quando não há sorteios para comparar.
        /// </summary>
        public int NaoSorteados => MelhorAcerto < 0 ? -1 : Numeros.Count - MelhorAcerto;
    }

    public class ApostaUsuarioResumo
    {
        public int ApostaId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataApuracao { get; set; }
    }

    public class SorteioAcertoResumo
    {
        public int NuSorteio { get; set; }
        public DateTime? DataApuracao { get; set; }
        public int Acertos { get; set; }

        /// <summary>Números da aposta que saíram nesse sorteio (interseção).</summary>
        public List<int> NumerosAcertados { get; set; } = new();
    }
}
