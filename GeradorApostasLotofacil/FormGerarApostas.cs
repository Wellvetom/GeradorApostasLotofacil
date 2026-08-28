using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Session;

namespace GeradorApostasLotofacil
{
    public partial class FormGerarApostas : Form
    {
        private readonly IGeracaoService _geracaoService;
        private readonly IApostaService _apostaService;
        private readonly UsuarioSession _usuarioSession;
        private List<JogoModel>? _jogosSalvos;

        public FormGerarApostas(
            IGeracaoService geracaoService,
            IApostaService apostaService,
            UsuarioSession usuarioSession)
        {
            InitializeComponent();
            _geracaoService = geracaoService;
            _apostaService = apostaService;
            _usuarioSession = usuarioSession;
        }

        private void btn_gerarApostas_Click(object sender, EventArgs e)
        {
            try
            {
                var apostas = _geracaoService.GerarJogosInteligentes(numberBox_quantidadeApostas.Value);

                if (apostas.Jogos.Any())
                {
                    _jogosSalvos = apostas.Jogos;
                    dgv_listaApostas.AutoGenerateColumns = false;

                    // Create a display-friendly list for the DataGridView
                    var displayList = apostas.Jogos.Select(j => new Helper.ApostaGridViewModel
                    {
                        Numeros = j.Numeros
                    }).ToList();

                    dgv_listaApostas.DataSource = displayList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar apostas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGravarApostas_Click(object sender, EventArgs e)
        {
            try
            {
                if (_jogosSalvos == null || !_jogosSalvos.Any())
                {
                    MessageBox.Show("Nenhuma aposta gerada para gravar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var retornoRobo = await new LoteriasCaixaRobot.Interface.BuscaSorteioInterface()
                    .BuscaUltimoSorteio(LoteriasCaixaRobot.Request.BaseRequest.TipoSorteio.Lotofacil);

                var aposta = new ApostaModel()
                {
                    Jogos = _jogosSalvos,
                    DataInclusao = DateTime.Now,
                    DataApuracao = retornoRobo.DataProximoSorteio,
                    UsuarioId = _usuarioSession.UsuarioLogado.Id
                };

                await _apostaService.GravarApostas(aposta);
                MessageBox.Show("Apostas gravadas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gravar apostas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
