using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.DTO;
using GeradorApostasLotofacil.Session;

namespace GeradorApostasLotofacil
{
    public partial class FormDashboardAdmin : Form
    {
        private readonly IAdminDashboardService _adminDashboardService;
        private readonly UsuarioSession _usuarioSession;
        private readonly LoteriaConfig _config;
        private AdminDashboardViewModel? _dados;
        private readonly LoadingPanel _loadingPanel;

        public FormDashboardAdmin(
            IAdminDashboardService adminDashboardService,
            UsuarioSession usuarioSession,
            LoteriaConfig config)
        {
            InitializeComponent();
            _adminDashboardService = adminDashboardService;
            _usuarioSession = usuarioSession;
            _config = config;

            _loadingPanel = new LoadingPanel();
            this.Controls.Add(_loadingPanel);
        }

        private async void FormDashboardAdmin_Load(object sender, EventArgs e)
        {
            // Esconde todos os controles do form para mostrar apenas o loading
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != _loadingPanel)
                    ctrl.Visible = false;
            }

            await CarregarDashboard();

            // Mostra os controles após carregar
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != _loadingPanel)
                    ctrl.Visible = true;
            }

            // Reinicia a animação dos gráficos agora que estão visíveis
            pieMaisSairam.Replay();
            pieMenosSairam.Replay();
        }

        private async Task CarregarDashboard()
        {
            try
            {
                _loadingPanel.Exibir("Carregando dados...");

                // Executa o serviço completo em Task.Run pois ele contém processamento pesado O(n²)
                // O DbContext é scoped e usado apenas dentro desta chamada
                _dados = await Task.Run(async () => await _adminDashboardService.ObterDashboardAdmin());

                PreencherCards();
                PreencherNumerosQueMaisSairam();
                PreencherNumerosQueMenosSairam();
                PreencherUltimosSorteios();
                PreencherParesComuns();

                _loadingPanel.Ocultar();
            }
            catch (Exception ex)
            {
                _loadingPanel.Ocultar();
                lblStatus.Text = $"Erro: {ex.Message}";
                lblStatus.Visible = true;
                MessageBox.Show($"Erro ao carregar dashboard admin: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherCards()
        {
            try
            {
                if (_dados == null) return;

                lblTotalSorteios.Text = _dados.TotalSorteiosImportados.ToString();
                lblUltimoSorteio.Text = _dados.UltimoSorteioNumero > 0 ? $"Nº {_dados.UltimoSorteioNumero}" : "—";
                lblDataUltimo.Text = _dados.DataUltimoSorteio?.ToString("dd/MM/yyyy") ?? "—";
                lblJogosRepetidos.Text = _dados.JogosRepetidos.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher cards: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PreencherNumerosQueMaisSairam()
        {
            try
            {
                if (_dados == null) return;

                pieMaisSairam.SetData(
                    _dados.NumerosQueMaisSairam
                        .Select(n => new Controls.PieChartControl.Fatia(n.Numero.ToString("D2"), n.Frequencia)));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro números mais sorteados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PreencherNumerosQueMenosSairam()
        {
            try
            {
                if (_dados == null) return;

                pieMenosSairam.SetData(
                    _dados.NumerosQueMenosSairam
                        .Select(n => new Controls.PieChartControl.Fatia(n.Numero.ToString("D2"), n.Frequencia)));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro números menos sorteados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PreencherUltimosSorteios()
        {
            try
            {
                if (_dados == null) return;

                dgvUltimosSorteios.DataSource = _dados.UltimosSorteios
                    .Select(s => new
                    {
                        Sorteio = s.NuSorteio,
                        Data = s.DataApuracao?.ToString("dd/MM/yyyy") ?? "—",
                        Números = string.Join(" - ", s.Numeros.Select(n => n.ToString("D2")))
                    })
                    .ToList();

                dgvUltimosSorteios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro últimos sorteios: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PreencherParesComuns()
        {
            try
            {
                if (_dados == null) return;

                // Mapeia as 3 grades fixas da UI às 3 faixas de "números em comum" da modalidade.
                // Lotofácil: 12,13,14. Mega Sena: 3,4,5.
                var faixas = _config.FaixasParesComuns.OrderBy(f => f).ToList();
                var grids = new[] { dgvComum12, dgvComum13, dgvComum14 };
                var titulos = new[] { lblTituloComum12, lblTituloComum13, lblTituloComum14 };

                for (int i = 0; i < grids.Length; i++)
                {
                    if (i < faixas.Count)
                    {
                        int faixa = faixas[i];
                        var pares = _dados.ObterPares(faixa);

                        grids[i].DataSource = pares
                            .Select(p => new { Sorteio_A = p.Sorteio1, Sorteio_B = p.Sorteio2, Comuns = p.NumerosComuns })
                            .ToList();
                        grids[i].AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        grids[i].Visible = true;
                        titulos[i].Text = $"🔗 {faixa} em comum ({pares.Count})";
                        titulos[i].Visible = true;
                    }
                    else
                    {
                        // Modalidade com menos faixas que grades disponíveis: oculta as sobrando.
                        grids[i].DataSource = null;
                        grids[i].Visible = false;
                        titulos[i].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher pares comuns: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
