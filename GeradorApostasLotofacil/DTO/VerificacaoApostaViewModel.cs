namespace GeradorApostasLotofacil.DTO
{
    /// <summary>
    /// Resultado da verificação de uma aposta informada pelo usuário.
    /// Indica se o usuário já apostou esses números e se eles já foram sorteados
    /// oficialmente, agrupados por faixa de acertos (dependente da modalidade).
    /// </summary>
    public class VerificacaoApostaViewModel
    {
        /// <summary>Números informados para verificação (ordenados).</summary>
        public List<int> Numeros { get; set; } = new();

        /// <summary>Indica se o usuário já apostou exatamente esses números.</summary>
        public bool JaApostou => ApostasDoUsuario.Count > 0;

        /// <summary>
        /// Ocorrências dessa aposta feitas pelo próprio usuário (data de inclusão e do sorteio).
        /// </summary>
        public List<ApostaUsuarioResumo> ApostasDoUsuario { get; set; } = new();

        /// <summary>
        /// Sorteios oficiais em que esses números tiveram interseção relevante com o resultado,
        /// agrupados por quantidade de acertos. A chave é a faixa (ex.: 15,14,13,12 na Lotofácil;
        /// 6,5,4 na Mega Sena).
        /// </summary>
        public Dictionary<int, List<SorteioAcertoResumo>> SorteiosPorFaixa { get; set; } = new();

        /// <summary>Obtém a lista de sorteios de uma faixa (vazia se não houver).</summary>
        public List<SorteioAcertoResumo> ObterFaixa(int acertos) =>
            SorteiosPorFaixa.TryGetValue(acertos, out var lista) ? lista : new List<SorteioAcertoResumo>();

        // ---- Compatibilidade com telas da Lotofácil (faixas fixas 15..12) ----
        public List<SorteioAcertoResumo> Sorteios15 => ObterFaixa(15);
        public List<SorteioAcertoResumo> Sorteios14 => ObterFaixa(14);
        public List<SorteioAcertoResumo> Sorteios13 => ObterFaixa(13);
        public List<SorteioAcertoResumo> Sorteios12 => ObterFaixa(12);

        /// <summary>Indica se houve algum sorteio oficial dentro das faixas rastreadas.</summary>
        public bool JaFoiSorteado => SorteiosPorFaixa.Values.Any(l => l.Count > 0);

        /// <summary>Total de sorteios encontrados em todas as faixas rastreadas.</summary>
        public int TotalSorteiosEncontrados => SorteiosPorFaixa.Values.Sum(l => l.Count);

        /// <summary>
        /// Maior quantidade de acertos obtida entre todos os sorteios oficiais
        /// (mesmo abaixo das faixas rastreadas). -1 quando não há sorteios oficiais para comparar.
        /// </summary>
        public int MelhorAcerto { get; set; } = -1;

        /// <summary>Concurso do sorteio em que ocorreu o melhor acerto (0 se indefinido).</summary>
        public int MelhorConcurso { get; set; }

        /// <summary>Data de apuração do sorteio em que ocorreu o melhor acerto.</summary>
        public DateTime? MelhorData { get; set; }

        /// <summary>
        /// Quantos dos números selecionados NÃO foram sorteados no melhor resultado.
        /// Corresponde a (NumerosSelecionados - MelhorAcerto). -1 quando não há sorteios para comparar.
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
