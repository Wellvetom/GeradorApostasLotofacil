using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Repository;

namespace GeradorApostasLotofacil.Application
{
    public class ImportacaoService : IImportacaoService
    {
        private readonly IApostaRepository _repo;

        public ImportacaoService(IApostaRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> ImportarApostas()
        {
            try
            {
                var ultimoSorteio = await new LoteriasCaixaRobot.Interface.BuscaSorteioInterface()
                    .BuscaSorteio(LoteriasCaixaRobot.Request.BaseRequest.TipoSorteio.Lotofacil);
                var ultimoSorteioGravado = await _repo.ObterUltima();

                if (ultimoSorteio == null)
                    return false;

                bool finaliza = true;
                var NuSorteio = ultimoSorteio.Aposta.NuSorteio;
                var idSor = ultimoSorteioGravado is null ? 1 : ultimoSorteioGravado.NuSorteio;

                if (idSor == NuSorteio)
                    finaliza = false;

                while (finaliza)
                {
                    idSor++;
                    var buscaSorteio = await new LoteriasCaixaRobot.Interface.BuscaSorteioInterface()
                        .BuscaSorteio(LoteriasCaixaRobot.Request.BaseRequest.TipoSorteio.Lotofacil, idSorteio: idSor);

                    var jogoVencedor = buscaSorteio.Aposta.JogoVencedor;
                    var numerosJogo = new List<int>
                    {
                        jogoVencedor.PrimeiroNumero,
                        jogoVencedor.SegundoNumero,
                        jogoVencedor.TerceiroNumero,
                        jogoVencedor.QuartoNumero,
                        jogoVencedor.QuintoNumero,
                        jogoVencedor.SextoNumero,
                        jogoVencedor.SetimoNumero,
                        jogoVencedor.OitavoNumero,
                        jogoVencedor.NonoNumero,
                        jogoVencedor.DecimoNumero,
                        jogoVencedor.DecimoPrimeiroNumero,
                        jogoVencedor.DecimoSegundoNumero,
                        jogoVencedor.DecimoTerceiroNumero,
                        jogoVencedor.DecimoQuartoNumero,
                        jogoVencedor.DecimoQuintoNumero
                    };

                    ApostaModel gravarAposta = new ApostaModel()
                    {
                        DataApuracao = buscaSorteio.Aposta.DataApuracao,
                        DataInclusao = DateTime.Now,
                        NuSorteio = buscaSorteio.Aposta.NuSorteio,
                        Jogos = new List<JogoModel>()
                    };

                    JogoModel gravarJogo = new JogoModel()
                    {
                        Numeros = numerosJogo
                    };

                    gravarAposta.Jogos.Add(gravarJogo);
                    await _repo.Salvar(gravarAposta);

                    if (idSor == NuSorteio)
                        finaliza = false;
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
