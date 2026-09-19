using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.DTO;
using GeradorApostasLotofacil.Session;

namespace GeradorApostasLotofacil
{
    public partial class FormDashboard : Form
    {
        private readonly IDashboardService _dashboardService;
        private readonly IConferenciaService _conferenciaService;
        private readonly UsuarioSession _usuarioSession;
        private DashboardViewModel? _dados;
        private readonly LoadingPanel _loadingPanel;

        public FormDashboard(
            IDashboardService dashboardService,
            IConferenciaService conferenciaService,
            UsuarioSession usuarioSession)
        {
            InitializeComponent();
            _dashboardService = dashboardService;
            _conferenciaService = conferenciaService;
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
                PreencherComboJogos();
                panelGraficoAcertos.Invalidate();
                panelJogosPorDia.Invalidate();

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

        /// <summary>Item do ComboBox que carrega o jogo do usuário selecionado.</summary>
        private sealed class JogoComboItem
        {
            public DashboardJogoResumo Jogo { get; init; } = null!;
            public string Texto { get; init; } = string.Empty;
            public override string ToString() => Texto;
        }

        private void PreencherComboJogos()
        {
            try
            {
                cmbJogos.Items.Clear();
                lblResultadoVerificacao.Text = "—";
                lblResultadoVerificacao.ForeColor = Color.FromArgb(210, 210, 230);
                dgvVerificacaoSorteios.DataSource = null;

                if (_dados == null || _dados.TodosOsJogos.Count == 0)
                {
                    btnVerificarJogo.Enabled = false;
                    cmbJogos.Enabled = false;
                    lblResultadoVerificacao.Text = "Você ainda não tem jogos criados.";
                    return;
                }

                foreach (var jogo in _dados.TodosOsJogos)
                {
                    var numeros = string.Join(" - ", jogo.Numeros.OrderBy(n => n).Select(n => n.ToString("D2")));
                    var texto = $"{jogo.DataAposta:dd/MM/yyyy}  |  {numeros}";
                    cmbJogos.Items.Add(new JogoComboItem { Jogo = jogo, Texto = texto });
                }

                cmbJogos.Enabled = true;
                btnVerificarJogo.Enabled = true;
                if (cmbJogos.Items.Count > 0)
                    cmbJogos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao preencher lista de jogos.\n\nErro: {ex.Message}",
                    "Erro - PreencherComboJogos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnVerificarJogo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_usuarioSession.EstaAutenticado || _usuarioSession.UsuarioLogado == null)
                {
                    MessageBox.Show("Sessão expirada. Faça login novamente.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbJogos.SelectedItem is not JogoComboItem item)
                {
                    MessageBox.Show("Selecione um jogo para verificar.", "Seleção necessária",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var numeros = item.Jogo.Numeros.Distinct().OrderBy(n => n).ToList();
                if (numeros.Count != 15)
                {
                    MessageBox.Show(
                        $"O jogo selecionado possui {numeros.Count} números. A verificação requer 15 números.",
                        "Jogo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _loadingPanel.Exibir("Verificando jogo...");

                var resultado = await Task.Run(async () =>
                    await _conferenciaService.VerificarAposta(_usuarioSession.UsuarioLogado.Id, numeros));

                PreencherResultadoVerificacao(resultado);

                _loadingPanel.Ocultar();
            }
            catch (Exception ex)
            {
                _loadingPanel.Ocultar();
                MessageBox.Show($"Erro ao verificar jogo: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherResultadoVerificacao(VerificacaoApostaViewModel r)
        {
            // Resumo textual por faixa de acertos.
            if (r.JaFoiSorteado)
            {
                lblResultadoVerificacao.ForeColor = Color.FromArgb(255, 200, 100);
                lblResultadoVerificacao.Text =
                    $"🏆 Já foi sorteado!\n15: {r.Sorteios15.Count} | 14: {r.Sorteios14.Count} | " +
                    $"13: {r.Sorteios13.Count} | 12: {r.Sorteios12.Count}";
            }
            else if (r.MelhorAcerto < 0)
            {
                lblResultadoVerificacao.ForeColor = Color.FromArgb(210, 210, 230);
                lblResultadoVerificacao.Text = "Sem sorteios oficiais importados para comparar.";
            }
            else
            {
                lblResultadoVerificacao.ForeColor = Color.FromArgb(210, 210, 230);
                var data = r.MelhorData?.ToString("dd/MM/yyyy");
                var origem = r.MelhorConcurso > 0 ? $"concurso {r.MelhorConcurso}" : "sorteio";
                var complemento = data != null ? $" ({origem} — {data})" : "";
                lblResultadoVerificacao.Text =
                    $"❌ Nunca saiu com 12+.\nMelhor: {r.MelhorAcerto} acertos{complemento}";
            }

            // Grid: sorteios com 12+ acertos ordenados por faixa (15→12) e data.
            var linhas = r.Sorteios15
                .Concat(r.Sorteios14)
                .Concat(r.Sorteios13)
                .Concat(r.Sorteios12)
                .Select(s => new
                {
                    Acertos = $"{s.Acertos}",
                    Concurso = s.NuSorteio > 0 ? s.NuSorteio.ToString() : "—",
                    Data = s.DataApuracao?.ToString("dd/MM/yyyy") ?? "—",
                    Números = string.Join(" - ", s.NumerosAcertados.Select(n => n.ToString("D2")))
                })
                .ToList();

            dgvVerificacaoSorteios.DataSource = linhas;
            dgvVerificacaoSorteios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void panelJogosPorDia_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Título
            g.DrawString("📅 Jogos por Dia",
                new Font("Segoe UI", 10F, FontStyle.Bold), Brushes.White,
                new PointF(15, 8));

            if (_dados == null || _dados.JogosPorDia.Count == 0)
            {
                g.DrawString("Sem jogos registrados para exibir",
                    new Font("Segoe UI", 10F), Brushes.White,
                    new PointF(15, panelJogosPorDia.Height / 2 - 10));
                return;
            }

            // Exibe os últimos 15 dias com jogos (mantém o gráfico legível)
            var dados = _dados.JogosPorDia
                .OrderBy(d => d.Dia)
                .TakeLast(15)
                .ToList();

            int padding = 40;
            int topOffset = 40;
            int chartHeight = panelJogosPorDia.Height - padding - topOffset;
            int chartWidth = panelJogosPorDia.Width - padding * 2;
            int maxValue = dados.Max(d => d.Quantidade);

            // Eixos
            var penAxis = new Pen(Color.FromArgb(150, 255, 255, 255), 1);
            g.DrawLine(penAxis, padding, topOffset, padding, topOffset + chartHeight);
            g.DrawLine(penAxis, padding, topOffset + chartHeight, padding + chartWidth, topOffset + chartHeight);

            int n = dados.Count;
            int slot = chartWidth / n;
            int barWidth = Math.Min(50, Math.Max(12, slot - 12));

            var corBarra = Color.FromArgb(0, 150, 136);
            var fontLabel = new Font("Segoe UI", 8F);
            var fontValor = new Font("Segoe UI", 8F, FontStyle.Bold);

            for (int i = 0; i < n; i++)
            {
                var (dia, quantidade) = dados[i];

                int barHeight = maxValue > 0
                    ? (int)((double)quantidade / maxValue * (chartHeight - 25))
                    : 0;

                int x = padding + i * slot + (slot - barWidth) / 2;
                int y = topOffset + (chartHeight - barHeight);

                using (var brush = new SolidBrush(corBarra))
                    g.FillRectangle(brush, x, y, barWidth, barHeight);

                // Valor acima da barra
                g.DrawString(quantidade.ToString(), fontValor, Brushes.White,
                    new PointF(x + barWidth / 2f - 6, y - 16));

                // Data abaixo (dd/MM) rotacionada para caber
                var state = g.Save();
                g.TranslateTransform(x + barWidth / 2f, topOffset + chartHeight + 5);
                g.RotateTransform(35);
                g.DrawString(dia.ToString("dd/MM"), fontLabel, Brushes.White, new PointF(0, 0));
                g.Restore(state);
            }
        }
    }
}
