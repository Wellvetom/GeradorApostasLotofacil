using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using GeradorApostasLotofacil.Domain;

namespace GeradorApostasLotofacil.Application
{
    /// <summary>
    /// Resultado de um sorteio consultado diretamente na API da Caixa.
    /// A lista de dezenas tem tamanho variável conforme a modalidade
    /// (15 na Lotofácil, 6 na Mega Sena), o que corrige a limitação da
    /// DLL de RPA (parser fixo de 15 dezenas).
    /// </summary>
    public sealed class SorteioCaixa
    {
        public int NuSorteio { get; init; }
        public DateTime DataApuracao { get; init; }
        public DateTime? DataProximoSorteio { get; init; }
        public List<int> Dezenas { get; init; } = new();
    }

    /// <summary>
    /// Cliente HTTP para a API pública de resultados da Caixa, parametrizado
    /// por <see cref="LoteriaConfig.ApiSlug"/>. Substitui o uso da
    /// LoteriasCaixaRobot.dll, cujo parser era fixo em 15 dezenas e quebrava
    /// para a Mega Sena (6 dezenas).
    /// </summary>
    public interface ICaixaLoteriaClient
    {
        /// <summary>Obtém o último sorteio divulgado da modalidade.</summary>
        Task<SorteioCaixa> ObterUltimoAsync();

        /// <summary>Obtém um concurso específico da modalidade.</summary>
        Task<SorteioCaixa> ObterPorConcursoAsync(int concurso);
    }

    public sealed class CaixaLoteriaClient : ICaixaLoteriaClient
    {
        private const string BaseUrl = "https://servicebus2.caixa.gov.br/portaldeloterias/api/";

        private readonly LoteriaConfig _config;

        // HttpClient único e reutilizável (evita esgotamento de sockets).
        private static readonly HttpClient Http = CriarHttpClient();

        public CaixaLoteriaClient(LoteriaConfig config)
        {
            _config = config;
        }

        private static HttpClient CriarHttpClient()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip
                                       | System.Net.DecompressionMethods.Deflate
            };

            var client = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(30)
            };

            // A API da Caixa rejeita requisições sem um User-Agent "de navegador".
            client.DefaultRequestHeaders.TryAddWithoutValidation(
                "User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0 Safari/537.36");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

            return client;
        }

        public Task<SorteioCaixa> ObterUltimoAsync() => BuscarAsync(concurso: null);

        public Task<SorteioCaixa> ObterPorConcursoAsync(int concurso) => BuscarAsync(concurso);

        private async Task<SorteioCaixa> BuscarAsync(int? concurso)
        {
            // Ex.: .../api/megasena  (último)  ou  .../api/megasena/3080 (concurso)
            var url = concurso.HasValue
                ? $"{BaseUrl}{_config.ApiSlug}/{concurso.Value}"
                : $"{BaseUrl}{_config.ApiSlug}";

            using var resposta = await Http.GetAsync(url);
            resposta.EnsureSuccessStatusCode();

            var json = await resposta.Content.ReadAsStringAsync();
            return Parsear(json);
        }

        /// <summary>
        /// Converte o JSON da API da Caixa em <see cref="SorteioCaixa"/>.
        /// A quantidade de dezenas é a que vier em "listaDezenas" (variável por modalidade).
        /// </summary>
        private static SorteioCaixa Parsear(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            int numero = root.TryGetProperty("numero", out var nEl) && nEl.TryGetInt32(out var n) ? n : 0;

            DateTime dataApuracao = LerData(root, "dataApuracao") ?? DateTime.MinValue;
            DateTime? dataProximo = LerData(root, "dataProximoConcurso");

            var dezenas = new List<int>();
            if (root.TryGetProperty("listaDezenas", out var listaEl) && listaEl.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in listaEl.EnumerateArray())
                {
                    var txt = item.GetString();
                    if (int.TryParse(txt, NumberStyles.Integer, CultureInfo.InvariantCulture, out var dezena))
                        dezenas.Add(dezena);
                }
            }

            return new SorteioCaixa
            {
                NuSorteio = numero,
                DataApuracao = dataApuracao,
                DataProximoSorteio = dataProximo,
                Dezenas = dezenas.OrderBy(d => d).ToList()
            };
        }

        /// <summary>Lê uma data no formato dd/MM/yyyy de uma propriedade do JSON.</summary>
        private static DateTime? LerData(JsonElement root, string propriedade)
        {
            if (root.TryGetProperty(propriedade, out var el) && el.ValueKind == JsonValueKind.String)
            {
                var texto = el.GetString();
                if (!string.IsNullOrWhiteSpace(texto) &&
                    DateTime.TryParseExact(texto, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out var data))
                {
                    return data;
                }
            }
            return null;
        }
    }
}
