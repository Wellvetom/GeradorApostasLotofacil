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
        private readonly LoadingPanel _loadingPanel;

        public FormGerarApostas(
            IGeracaoService geracaoService,
            IApostaService apostaService,
            UsuarioSession usuarioSession)
        {
            InitializeComponent();
            _geracaoService = geracaoService;
            _apostaService = apostaService;
            _usuarioSession = usuarioSession;

            _loadingPanel = new LoadingPanel();
            this.Controls.Add(_loadingPanel);
        }

        private void btn_gerarApostas_Click(object sender, EventArgs e)
        {
            try
            {
                int maisSorteados = (int)numMaisSorteados.Value;
                int menosSorteados = (int)numMenosSorteados.Value;

                if (maisSorteados + menosSorteados > 15)
                {
                    MessageBox.Show("A soma dos mais sorteados + menos sorteados não pode ultrapassar 15.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var apostas = _geracaoService.GerarJogosInteligentes(
                    numberBox_quantidadeApostas.Value,
                    maisSorteados,
                    menosSorteados);

                if (apostas.Jogos.Any())
                {
                    _jogosSalvos = apostas.Jogos;
                    dgv_listaApostas.AutoGenerateColumns = false;

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

                _loadingPanel.Exibir("Gravando apostas...");

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

                _loadingPanel.Ocultar();
                MessageBox.Show("Apostas gravadas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _loadingPanel.Ocultar();
                MessageBox.Show($"Erro ao gravar apostas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numMaisMenos_ValueChanged(object? sender, EventArgs e)
        {
            int mais = (int)numMaisSorteados.Value;
            int menos = (int)numMenosSorteados.Value;
            int aleatorios = 15 - mais - menos;

            if (aleatorios < 0)
            {
                // Ajusta automaticamente para não ultrapassar 15
                if (sender == numMaisSorteados)
                    numMaisSorteados.Value = 15 - menos;
                else
                    numMenosSorteados.Value = 15 - mais;

                aleatorios = 0;
            }

            label_aleatorios.Text = $"🎲 Aleatórios: {aleatorios}";
        }
    }
}
