using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Helper;
using GeradorApostasLotofacil.Session;

namespace GeradorApostasLotofacil
{
    public partial class FormImportarApostas : Form
    {
        private readonly IApostaService _apostaService;
        private readonly IImportacaoService _importacaoService;
        private readonly ICaixaLoteriaClient _caixa;
        private readonly UsuarioSession _usuarioSession;
        private readonly LoteriaConfig _config;
        private readonly LoadingPanel _loadingPanel;

        public FormImportarApostas(
            IApostaService apostaService,
            IImportacaoService importacaoService,
            ICaixaLoteriaClient caixa,
            UsuarioSession usuarioSession,
            LoteriaConfig config)
        {
            InitializeComponent();
            _apostaService = apostaService;
            _importacaoService = importacaoService;
            _caixa = caixa;
            _usuarioSession = usuarioSession;
            _config = config;

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

                var ultimoSorteio = await _caixa.ObterUltimoAsync();

                if (ultimoSorteio != null && ultimoSorteio.NuSorteio > 0)
                {
                    var proximo = ultimoSorteio.DataProximoSorteio?.ToString("dd/MM/yyyy") ?? "a definir";
                    label_dadosApostas.Text =
                        $"Último sorteio (nº {ultimoSorteio.NuSorteio}) realizado em: {ultimoSorteio.DataApuracao:dd/MM/yyyy}\n" +
                        $"O próximo sorteio será realizado em: {proximo} ";
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
