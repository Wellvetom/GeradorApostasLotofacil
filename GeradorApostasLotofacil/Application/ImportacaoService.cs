using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Repository;

namespace GeradorApostasLotofacil.Application
{
    public class ImportacaoService : IImportacaoService
    {
        private readonly IApostaRepository _repo;
        private readonly ICaixaLoteriaClient _caixa;
        private readonly LoteriaConfig _config;

        public ImportacaoService(IApostaRepository repo, ICaixaLoteriaClient caixa, LoteriaConfig config)
        {
            _repo = repo;
            _caixa = caixa;
            _config = config;
        }

        public async Task<bool> ImportarApostas()
        {
            try
            {
                // Último concurso divulgado pela Caixa (dezenas de tamanho variável conforme a modalidade).
                var ultimoSorteio = await _caixa.ObterUltimoAsync();
                if (ultimoSorteio == null || ultimoSorteio.NuSorteio <= 0)
                    return false;

                var ultimoSorteioGravado = await _repo.ObterUltima(_config.Modalidade);

                int ultimoNumeroApi = ultimoSorteio.NuSorteio;
                // Começa do próximo concurso ainda não gravado (ou do 1º se a base estiver vazia).
                int proximo = ultimoSorteioGravado is null ? 1 : ultimoSorteioGravado.NuSorteio + 1;

                // Já está tudo importado.
                if (proximo > ultimoNumeroApi)
                    return true;

                for (int concurso = proximo; concurso <= ultimoNumeroApi; concurso++)
                {
                    // Reaproveita o payload já obtido para o último concurso; busca os demais.
                    var sorteio = concurso == ultimoNumeroApi
                        ? ultimoSorteio
                        : await _caixa.ObterPorConcursoAsync(concurso);

                    if (sorteio == null || sorteio.Dezenas.Count == 0)
                        continue;

                    // Garantia de consistência: usa exatamente a quantidade de dezenas da modalidade.
                    var numerosJogo = sorteio.Dezenas
                        .OrderBy(d => d)
                        .Take(_config.NumerosPorJogo)
                        .ToList();

                    var gravarAposta = new ApostaModel
                    {
                        Modalidade = _config.Modalidade,
                        DataApuracao = sorteio.DataApuracao,
                        DataInclusao = DateTime.Now,
                        NuSorteio = sorteio.NuSorteio,
                        Jogos = new List<JogoModel>
                        {
                            new JogoModel { Numeros = numerosJogo }
                        }
                    };

                    await _repo.Salvar(gravarAposta);
                }

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao importar apostas: {ex.Message}");
                return false;
            }
        }
    }
}
