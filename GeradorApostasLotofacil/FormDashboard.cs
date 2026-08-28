using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.DTO;
using GeradorApostasLotofacil.Session;

namespace GeradorApostasLotofacil
{
    public partial class FormDashboard : Form
    {
        private readonly IDashboardService _dashboardService;
        private readonly UsuarioSession _usuarioSession;
        private DashboardViewModel? _dados;

        public FormDashboard(
            IDashboardService dashboardService,
            UsuarioSession usuarioSession)
        {
            InitializeComponent();
            _dashboardService = dashboardService;
            _usuarioSession = usuarioSession;
        }

        private async void FormDashboard_Load(object sender, EventArgs e)
        {
            await CarregarDashboard();
        }

        private async Task CarregarDashboard()
        {
            try
            {
                if (!_usuarioSession.EstaAutenticado)
                {
                    lblStatus.Text = "Usuário não autenticado.";
                    return;
                }

                lblStatus.Text = "Carregando dados...";
                lblStatus.Visible = true;

                _dados = await _dashboardService.ObterDashboard(_usuarioSession.UsuarioLogado!.Id);

                PreencherCards();
                PreencherNumerosFrequentes();
                PreencherUltimasApostas();
                panelGraficoAcertos.Invalidate();

                lblStatus.Visible = false;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Erro ao carregar: {ex.Message}";
                MessageBox.Show($"Erro ao carregar dashboard: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherCards()
        {
            try
            {
                if (_dados == null) return;

                lblTotalApostas.Text = _dados.TotalApostas.ToString();
                lblTotalJogos.Text = _dados.TotalJogos.ToString();
                lblMelhorAcerto.Text = _dados.MelhorAcerto > 0 ? $"{_dados.MelhorAcerto} acertos" : "—";
                lblUltimaAposta.Text = _dados.UltimaApostaData?.ToString("dd/MM/yyyy") ?? "—";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao preencher cards.\n\nDados: TotalApostas={_dados?.TotalApostas}, TotalJogos={_dados?.TotalJogos}, MelhorAcerto={_dados?.MelhorAcerto}, UltimaData={_dados?.UltimaApostaData}\n\nErro: {ex.Message}\n\n{ex.StackTrace}",
                    "Erro - PreencherCards", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PreencherNumerosFrequentes()
        {
            try
            {
                if (_dados == null) return;

                dgvNumerosFrequentes.DataSource = _dados.NumerosFrequentes
                    .Select(n => new { Número = n.Numero.ToString("D2"), Frequência = n.Frequencia })
                    .ToList();

                dgvNumerosFrequentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                var numerosInfo = _dados?.NumerosFrequentes != null
                    ? $"Count={_dados.NumerosFrequentes.Count}, Itens=[{string.Join(", ", _dados.NumerosFrequentes.Select(n => $"({n.Numero}:{n.Frequencia})"))}]"
                    : "null";

                MessageBox.Show(
                    $"Erro ao preencher números frequentes.\n\nDados: {numerosInfo}\n\nErro: {ex.Message}\n\n{ex.StackTrace}",
                    "Erro - PreencherNumerosFrequentes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PreencherUltimasApostas()
        {
            try
            {
                if (_dados == null) return;

                dgvUltimasApostas.DataSource = _dados.UltimasApostas
                    .Select(a => new
                    {
                        a.Id,
                        Data = a.DataInclusao.ToString("dd/MM/yyyy"),
                        Apuração = a.DataApuracao?.ToString("dd/MM/yyyy") ?? "Pendente",
                        Jogos = a.QuantidadeJogos,
                        MelhorAcerto = a.MelhorAcerto > 0 ? $"{a.MelhorAcerto}" : "—"
                    })
                    .ToList();

                dgvUltimasApostas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                var apostasInfo = _dados?.UltimasApostas != null
                    ? $"Count={_dados.UltimasApostas.Count}, Itens=[{string.Join(", ", _dados.UltimasApostas.Select(a => $"(Id={a.Id}, Data={a.DataInclusao}, Jogos={a.QuantidadeJogos})"))}]"
                    : "null";

                MessageBox.Show(
                    $"Erro ao preencher últimas apostas.\n\nDados: {apostasInfo}\n\nErro: {ex.Message}\n\n{ex.StackTrace}",
                    "Erro - PreencherUltimasApostas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panelGraficoAcertos_Paint(object sender, PaintEventArgs e)
        {
            if (_dados == null || _dados.DistribuicaoAcertos.Count == 0)
            {
                e.Graphics.DrawString("Sem dados de acertos para exibir",
                    new Font("Segoe UI", 10F), Brushes.White,
                    new PointF(10, panelGraficoAcertos.Height / 2 - 10));
                return;
            }

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int padding = 40;
            int barWidth = 50;
            int spacing = 20;
            int maxValue = _dados.DistribuicaoAcertos.Values.Max();
            int chartHeight = panelGraficoAcertos.Height - padding * 2;
            int chartWidth = panelGraficoAcertos.Width - padding * 2;

            // Título
            g.DrawString("Distribuição de Acertos (11+)",
                new Font("Segoe UI", 10F, FontStyle.Bold), Brushes.White,
                new PointF(padding, 5));

            // Eixos
            var penAxis = new Pen(Color.FromArgb(150, 255, 255, 255), 1);
            g.DrawLine(penAxis, padding, padding + 20, padding, padding + chartHeight);
            g.DrawLine(penAxis, padding, padding + chartHeight, padding + chartWidth, padding + chartHeight);

            // Barras para acertos 11 a 15
            var cores = new Color[]
            {
                Color.FromArgb(255, 99, 132),   // 11
                Color.FromArgb(255, 159, 64),   // 12
                Color.FromArgb(255, 205, 86),   // 13
                Color.FromArgb(75, 192, 192),   // 14
                Color.FromArgb(54, 162, 235)    // 15
            };

            int x = padding + spacing;
            for (int acertos = 11; acertos <= 15; acertos++)
            {
                _dados.DistribuicaoAcertos.TryGetValue(acertos, out int quantidade);

                int barHeight = maxValue > 0
                    ? (int)((double)quantidade / maxValue * (chartHeight - 30))
                    : 0;

                int y = padding + 20 + (chartHeight - 30) - barHeight;
                int corIndex = acertos - 11;

                using var brush = new SolidBrush(cores[corIndex]);
                g.FillRectangle(brush, x, y, barWidth, barHeight);

                // Label acima da barra
                if (quantidade > 0)
                {
                    g.DrawString(quantidade.ToString(),
                        new Font("Segoe UI", 9F, FontStyle.Bold), Brushes.White,
                        new PointF(x + barWidth / 2 - 5, y - 18));
                }

                // Label abaixo (eixo X)
                g.DrawString($"{acertos}",
                    new Font("Segoe UI", 9F), Brushes.White,
                    new PointF(x + barWidth / 2 - 8, padding + chartHeight + 3));

                x += barWidth + spacing;
            }
        }
    }
}
