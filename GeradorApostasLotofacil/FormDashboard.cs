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
        private readonly LoadingPanel _loadingPanel;

        public FormDashboard(
            IDashboardService dashboardService,
            UsuarioSession usuarioSession)
        {
            InitializeComponent();
            _dashboardService = dashboardService;
            _usuarioSession = usuarioSession;

            _loadingPanel = new LoadingPanel();
            this.Controls.Add(_loadingPanel);
        }

        private async void FormDashboard_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != _loadingPanel)
                    ctrl.Visible = false;
            }

            await CarregarDashboard();

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != _loadingPanel)
                    ctrl.Visible = true;
            }

            // Reinicia a animação dos gráficos agora que estão visíveis
            pieNumerosFrequentes.Replay();
            pieAderencia.Replay();
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

                _loadingPanel.Exibir("Carregando dashboard...");

                _dados = await Task.Run(async () => await _dashboardService.ObterDashboard(_usuarioSession.UsuarioLogado!.Id));

                PreencherCards();
                PreencherNumerosFrequentes();
                PreencherUltimosJogos();
                PreencherAderencia();
                panelGraficoAcertos.Invalidate();

                _loadingPanel.Ocultar();
            }
            catch (Exception ex)
            {
                _loadingPanel.Ocultar();
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
                lblTaxaAcerto.Text = _dados.TaxaAcerto > 0 ? $"{_dados.TaxaAcerto:F1}%" : "—";
                lblNumeroSorte.Text = _dados.NumeroSorte > 0 ? _dados.NumeroSorte.ToString("D2") : "—";
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

                pieNumerosFrequentes.Titulo = string.Empty;
                pieNumerosFrequentes.SetData(
                    _dados.NumerosFrequentes
                        .Select(n => new Controls.PieChartControl.Fatia(n.Numero.ToString("D2"), n.Frequencia)));
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

        private void PreencherUltimosJogos()
        {
            try
            {
                if (_dados == null) return;

                dgvUltimasApostas.DataSource = _dados.UltimosJogos
                    .Select(j => new
                    {
                        Data = j.DataAposta.ToString("dd/MM/yyyy"),
                        Sorteio = j.DataSorteio?.ToString("dd/MM/yyyy") ?? "Pendente",
                        Números = string.Join(" - ", j.Numeros.Select(n => n.ToString("D2"))),
                        Acertos = j.Acertos > 0 ? $"{j.Acertos}" : "—"
                    })
                    .ToList();

                dgvUltimasApostas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao preencher últimos jogos.\n\nErro: {ex.Message}",
                    "Erro - PreencherUltimosJogos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PreencherAderencia()
        {
            try
            {
                if (_dados == null) return;

                pieAderencia.Titulo = string.Empty;
                pieAderencia.SetData(
                    _dados.NumerosAderencia
                        .Select(n => new Controls.PieChartControl.Fatia(n.Numero.ToString("D2"), n.Score)));
            }
            catch (Exception ex)
            {
                var info = _dados?.NumerosAderencia != null
                    ? $"Count={_dados.NumerosAderencia.Count}"
                    : "null";

                MessageBox.Show(
                    $"Erro ao preencher aderência.\n\nDados: {info}\n\nErro: {ex.Message}\n\n{ex.StackTrace}",
                    "Erro - PreencherAderencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
