using RpaTipoSorteio = LoteriasCaixaRobot.Request.BaseRequest.TipoSorteio;

namespace GeradorApostasLotofacil.Domain
{
    /// <summary>
    /// Configuração que parametriza toda a lógica de geração, conferência,
    /// importação e exibição para uma modalidade de loteria específica.
    /// Centraliza as constantes que antes estavam hardcoded (15/25, faixas 11-15 etc.).
    /// </summary>
    public sealed class LoteriaConfig
    {
        /// <summary>Modalidade associada a esta configuração.</summary>
        public Modalidade Modalidade { get; init; }

        /// <summary>Nome de exibição (ex.: "Lotofácil", "Mega Sena").</summary>
        public string Nome { get; init; } = string.Empty;

        /// <summary>Total de números do volante (25 na Lotofácil, 60 na Mega Sena).</summary>
        public int TotalNumeros { get; init; }

        /// <summary>Quantidade de números por jogo (15 na Lotofácil, 6 na Mega Sena).</summary>
        public int NumerosPorJogo { get; init; }

        /// <summary>
        /// Faixas de acerto consideradas "premiadas" / relevantes, em ordem decrescente.
        /// Lotofácil: 15,14,13,12,11. Mega Sena: 6,5,4.
        /// </summary>
        public IReadOnlyList<int> FaixasPremio { get; init; } = Array.Empty<int>();

        /// <summary>
        /// Faixas exibidas nas grades de "já foi sorteado" e verificação, em ordem decrescente.
        /// Lotofácil: 15,14,13,12. Mega Sena: 6,5,4.
        /// </summary>
        public IReadOnlyList<int> FaixasVerificacao { get; init; } = Array.Empty<int>();

        /// <summary>Menor faixa considerada premiada (11 na Lotofácil, 4 na Mega Sena).</summary>
        public int FaixaMinimaPremio => FaixasPremio.Count > 0 ? FaixasPremio.Min() : 0;

        /// <summary>Menor faixa exibida nas grades de verificação (12 na Lotofácil, 4 na Mega Sena).</summary>
        public int FaixaMinimaVerificacao => FaixasVerificacao.Count > 0 ? FaixasVerificacao.Min() : 0;

        /// <summary>
        /// Opções de "alvo de acertos" para geração por critério.
        /// Lotofácil: 11,12,13,14. Mega Sena: 4,5.
        /// </summary>
        public IReadOnlyList<int> CriterioAlvoOpcoes { get; init; } = Array.Empty<int>();

        /// <summary>
        /// Faixas de "números em comum" entre pares de sorteios exibidas no painel admin,
        /// em ordem crescente. Lotofácil: 12,13,14. Mega Sena: 3,4,5.
        /// </summary>
        public IReadOnlyList<int> FaixasParesComuns { get; init; } = Array.Empty<int>();

        /// <summary>Tipo de sorteio correspondente na RPA (LoteriasCaixaRobot).</summary>
        public RpaTipoSorteio TipoSorteio { get; init; }

        /// <summary>
        /// Slug da modalidade no endpoint da API da Caixa
        /// (ex.: "lotofacil", "megasena"). Usado para montar a URL
        /// https://servicebus2.caixa.gov.br/portaldeloterias/api/{ApiSlug}/{concurso}.
        /// </summary>
        public string ApiSlug { get; init; } = string.Empty;

        /// <summary>Texto de faixa para gráficos de distribuição (ex.: "11+", "4+").</summary>
        public string RotuloFaixaMinima => $"{FaixaMinimaPremio}+";

        public static LoteriaConfig Lotofacil { get; } = new LoteriaConfig
        {
            Modalidade = Modalidade.Lotofacil,
            Nome = "Lotofácil",
            TotalNumeros = 25,
            NumerosPorJogo = 15,
            FaixasPremio = new[] { 15, 14, 13, 12, 11 },
            FaixasVerificacao = new[] { 15, 14, 13, 12 },
            CriterioAlvoOpcoes = new[] { 11, 12, 13, 14 },
            FaixasParesComuns = new[] { 12, 13, 14 },
            TipoSorteio = RpaTipoSorteio.Lotofacil,
            ApiSlug = "lotofacil"
        };

        public static LoteriaConfig MegaSena { get; } = new LoteriaConfig
        {
            Modalidade = Modalidade.MegaSena,
            Nome = "Mega Sena",
            TotalNumeros = 60,
            NumerosPorJogo = 6,
            FaixasPremio = new[] { 6, 5, 4 },
            FaixasVerificacao = new[] { 6, 5, 4 },
            CriterioAlvoOpcoes = new[] { 4, 5 },
            FaixasParesComuns = new[] { 3, 4, 5 },
            TipoSorteio = RpaTipoSorteio.MegaSena,
            ApiSlug = "megasena"
        };

        /// <summary>Obtém a configuração para a modalidade informada.</summary>
        public static LoteriaConfig Obter(Modalidade modalidade) => modalidade switch
        {
            Modalidade.Lotofacil => Lotofacil,
            Modalidade.MegaSena => MegaSena,
            _ => throw new ArgumentOutOfRangeException(nameof(modalidade), modalidade, "Modalidade não suportada.")
        };
    }
}
