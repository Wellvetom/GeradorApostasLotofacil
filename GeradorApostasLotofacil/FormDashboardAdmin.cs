using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.DTO;
using GeradorApostasLotofacil.Session;

namespace GeradorApostasLotofacil
{
    public partial class FormDashboardAdmin : Form
    {
        private readonly IAdminDashboardService _adminDashboardService;
        private readonly UsuarioSession _usuarioSession;
        private AdminDashboardViewModel? _dados;
        private readonly LoadingPanel _loadingPanel;

        public FormDashboardAdmin(
            IAdminDashboardService adminDashboardService,
            UsuarioSession usuarioSession)
        {
            InitializeComponent();
            _adminDashboardService = adminDashboardService;
            _usuarioSession = usuarioSession;

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

                dgvMaisSairam.DataSource = _dados.NumerosQueMaisSairam
                    .Select(n => new { Número = n.Numero.ToString("D2"), Vezes = n.Frequencia })
                    .ToList();

                dgvMaisSairam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

                dgvMenosSairam.DataSource = _dados.NumerosQueMenosSairam
                    .Select(n => new { Número = n.Numero.ToString("D2"), Vezes = n.Frequencia })
                    .ToList();

                dgvMenosSairam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

                // Grid 12 em comum
                dgvComum12.DataSource = _dados.ParesCom12
                    .Select(p => new { Sorteio_A = p.Sorteio1, Sorteio_B = p.Sorteio2, Comuns = p.NumerosComuns })
                    .ToList();
                dgvComum12.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                lblTituloComum12.Text = $"🔗 12 em comum ({_dados.ParesCom12.Count})";

                // Grid 13 em comum
                dgvComum13.DataSource = _dados.ParesCom13
                    .Select(p => new { Sorteio_A = p.Sorteio1, Sorteio_B = p.Sorteio2, Comuns = p.NumerosComuns })
                    .ToList();
                dgvComum13.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                lblTituloComum13.Text = $"🔗 13 em comum ({_dados.ParesCom13.Count})";

                // Grid 14 em comum
                dgvComum14.DataSource = _dados.ParesCom14
                    .Select(p => new { Sorteio_A = p.Sorteio1, Sorteio_B = p.Sorteio2, Comuns = p.NumerosComuns })
                    .ToList();
                dgvComum14.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                lblTituloComum14.Text = $"🔗 14 em comum ({_dados.ParesCom14.Count})";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher pares comuns: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
