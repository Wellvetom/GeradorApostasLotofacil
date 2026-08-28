using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Helper;
using GeradorApostasLotofacil.Session;

namespace GeradorApostasLotofacil
{
    public partial class FormImportarApostas : Form
    {
        private readonly IApostaService _apostaService;
        private readonly IImportacaoService _importacaoService;
        private readonly UsuarioSession _usuarioSession;
        private readonly LoadingPanel _loadingPanel;

        public FormImportarApostas(
            IApostaService apostaService,
            IImportacaoService importacaoService,
            UsuarioSession usuarioSession)
        {
            InitializeComponent();
            _apostaService = apostaService;
            _importacaoService = importacaoService;
            _usuarioSession = usuarioSession;

            _loadingPanel = new LoadingPanel();
            this.Controls.Add(_loadingPanel);

            CarregarDados();
            CarregaUltimasApostas();
        }

        private async void btn_importarApostas_Click(object sender, EventArgs e)
        {
            try
            {
                _loadingPanel.Exibir("Importando resultados...");

                var retorno = await _importacaoService.ImportarApostas();

                _loadingPanel.Ocultar();

                if (retorno)
                {
                    MessageBox.Show("Processo finalizado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Não foi possível importar as apostas. Verifique a conexão.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                _loadingPanel.Ocultar();
                MessageBox.Show($"Erro ao importar apostas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CarregarDados()
        {
            try
            {
                _loadingPanel.Exibir("Carregando dados do sorteio...");

                var retornoRobo = await new LoteriasCaixaRobot.Interface.BuscaSorteioInterface()
                    .BuscaUltimoSorteio(LoteriasCaixaRobot.Request.BaseRequest.TipoSorteio.Lotofacil);

                if (retornoRobo.ProcessOK)
                {
                    label_dadosApostas.Text = $"Ultimo sorteio realizado em: {retornoRobo.DataUltimoSorteio.ToString("dd/MM/yyyy")}\nO proximo sorteio será realizado em: {retornoRobo.DataProximoSorteio.ToString("dd/MM/yyyy")} ";
                }

                _loadingPanel.Ocultar();
            }
            catch (Exception ex)
            {
                _loadingPanel.Ocultar();
                label_dadosApostas.Text = "Não foi possível carregar dados do sorteio.";
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar dados: {ex.Message}");
            }
        }

        private async void CarregaUltimasApostas()
        {
            try
            {
                var apostas = await _apostaService.ObterUltimas10();

                if (apostas.Any())
                {
                    var apostasBuscadas = apostas.SelectMany(a => a.Jogos.Select(j => new ApostaGridViewModel
                    {
                        Id = j.Id,
                        Numeros = j.Numeros,
                        Usuario = _usuarioSession.UsuarioLogado?.Username ?? "Sistema",
                        DataInclusao = a.DataApuracao?.ToString("dd/MM/yyyy") ?? "Pendente"
                    })).ToList();

                    dgv_listaApostas.DataSource = apostasBuscadas;
                    dgv_listaApostas.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar últimas apostas: {ex.Message}");
            }
        }
    }
}
