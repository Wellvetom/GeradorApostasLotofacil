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

        public FormDashboardAdmin(
            IAdminDashboardService adminDashboardService,
            UsuarioSession usuarioSession)
        {
            InitializeComponent();
            _adminDashboardService = adminDashboardService;
            _usuarioSession = usuarioSession;
        }

        private async void FormDashboardAdmin_Load(object sender, EventArgs e)
        {
            await CarregarDashboard();
        }

        private async Task CarregarDashboard()
        {
            try
            {
                lblStatus.Text = "Carregando dados administrativos...";
                lblStatus.Visible = true;

                _dados = await _adminDashboardService.ObterDashboardAdmin();

                PreencherCards();
                PreencherNumerosQueMaisSairam();
                PreencherNumerosQueMenosSairam();
                PreencherUltimosSorteios();

                lblStatus.Visible = false;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Erro: {ex.Message}";
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
    }
}
