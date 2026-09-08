using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.DTO;
using GeradorApostasLotofacil.Session;

namespace GeradorApostasLotofacil
{
    public partial class FormVerificarAposta : Form
    {
        private readonly IConferenciaService _conferenciaService;
        private readonly UsuarioSession _usuarioSession;
        private readonly LoadingPanel _loadingPanel;

        private const int TotalNumeros = 25;
        private const int NumerosPorAposta = 15;

        // Botões toggle de 1 a 25. O estado "selecionado" é guardado no Tag (bool).
        private readonly List<Button> _botoes = new();

        // Cores do estado dos botões
        private static readonly Color CorNaoSelecionado = Color.FromArgb(55, 65, 82);
        private static readonly Color CorSelecionado = Color.FromArgb(63, 81, 181);
        private static readonly Color CorTextoNaoSelecionado = Color.FromArgb(210, 210, 230);

        public FormVerificarAposta(
            IConferenciaService conferenciaService,
            UsuarioSession usuarioSession)
        {
            InitializeComponent();
            _conferenciaService = conferenciaService;
            _usuarioSession = usuarioSession;

            CriarBotoesNumeros();
            AtualizarContador();

            _loadingPanel = new LoadingPanel();
            this.Controls.Add(_loadingPanel);
        }

        /// <summary>Cria os 25 botões selecionáveis (1 a 25).</summary>
        private void CriarBotoesNumeros()
        {
            for (int i = 1; i <= TotalNumeros; i++)
            {
                var btn = new Button
                {
                    Text = i.ToString("D2"),
                    Tag = false, // estado: não selecionado
                    Width = 52,
                    Height = 44,
                    Margin = new Padding(5),
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = CorTextoNaoSelecionado,
                    BackColor = CorNaoSelecionado,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += NumeroBotao_Click;

                _botoes.Add(btn);
                flowNumeros.Controls.Add(btn);
            }
        }

        private void NumeroBotao_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn) return;

            bool selecionado = btn.Tag is true;

            if (!selecionado)
            {
                // Impede selecionar mais que 15
                if (ContarSelecionados() >= NumerosPorAposta)
                {
                    MessageBox.Show(
                        $"Você já selecionou {NumerosPorAposta} números. Desmarque algum para trocar.",
                        "Limite atingido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Selecionar(btn, true);
            }
            else
            {
                Selecionar(btn, false);
            }

            AtualizarContador();
        }

        private static void Selecionar(Button btn, bool selecionado)
        {
            btn.Tag = selecionado;
            btn.BackColor = selecionado ? CorSelecionado : CorNaoSelecionado;
            btn.ForeColor = selecionado ? Color.White : CorTextoNaoSelecionado;
        }

        private int ContarSelecionados() => _botoes.Count(b => b.Tag is true);

        private List<int> ObterNumerosSelecionados() =>
            _botoes
                .Where(b => b.Tag is true)
                .Select(b => int.Parse(b.Text))
                .OrderBy(n => n)
                .ToList();

        private void AtualizarContador()
        {
            int selecionados = ContarSelecionados();
            lblInstrucao.Text =
                $"Selecione 15 números (1 a 25) e clique em Verificar.  Selecionados: {selecionados}/{NumerosPorAposta}";

            // Habilita Verificar apenas quando exatamente 15 estão marcados.
            btnVerificar.Enabled = selecionados == NumerosPorAposta;
        }

        private async void btnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_usuarioSession.UsuarioLogado == null)
                {
                    MessageBox.Show("Sessão expirada. Faça login novamente.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var numeros = ObterNumerosSelecionados();

                // Com botões toggle, repetição é impossível; resta validar a quantidade.
                if (numeros.Count != NumerosPorAposta)
                {
                    MessageBox.Show($"Selecione exatamente {NumerosPorAposta} números.",
                        "Seleção incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _loadingPanel.Exibir("Verificando aposta...");

                var resultado = await _conferenciaService.VerificarAposta(
                    _usuarioSession.UsuarioLogado.Id, numeros);

                PreencherResultado(resultado);

                _loadingPanel.Ocultar();
            }
            catch (Exception ex)
            {
                _loadingPanel.Ocultar();
                MessageBox.Show($"Erro ao verificar aposta: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherResultado(VerificacaoApostaViewModel r)
        {
            // Card 1: já apostou?
            if (r.JaApostou)
            {
                var datas = string.Join(", ",
                    r.ApostasDoUsuario.Select(a => a.DataInclusao.ToString("dd/MM/yyyy")));
                lblJaApostou.ForeColor = Color.FromArgb(130, 200, 130);
                lblJaApostou.Text = $"✅ Sim — {r.ApostasDoUsuario.Count}x\n{datas}";
            }
            else
            {
                lblJaApostou.ForeColor = Color.FromArgb(210, 210, 230);
                lblJaApostou.Text = "❌ Não — você ainda não apostou esse jogo.";
            }

            // Card 2: já foi sorteado com 12+?
            if (r.JaFoiSorteado)
            {
                lblJaSorteado.ForeColor = Color.FromArgb(255, 200, 100);
                lblJaSorteado.Text =
                    $"🏆 Sim — 15: {r.Sorteios15.Count} | 14: {r.Sorteios14.Count} | " +
                    $"13: {r.Sorteios13.Count} | 12: {r.Sorteios12.Count}";
            }
            else
            {
                lblJaSorteado.ForeColor = Color.FromArgb(210, 210, 230);
                lblJaSorteado.Text = "❌ Não — nunca saiu com 12 ou mais acertos.";
            }

            // Grid: todos os sorteios com 12+ acertos, ordenados por faixa (15→12) e data.
            var linhas = r.Sorteios15
                .Concat(r.Sorteios14)
                .Concat(r.Sorteios13)
                .Concat(r.Sorteios12)
                .Select(s => new
                {
                    Faixa = $"{s.Acertos}",
                    Concurso = s.NuSorteio > 0 ? s.NuSorteio.ToString() : "—",
                    Data = s.DataApuracao?.ToString("dd/MM/yyyy") ?? "—",
                    Numeros = string.Join(" - ", s.NumerosAcertados.Select(n => n.ToString("D2")))
                })
                .ToList();

            dgvSorteios.AutoGenerateColumns = false;
            dgvSorteios.DataSource = linhas;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            foreach (var btn in _botoes)
                Selecionar(btn, false);

            AtualizarContador();

            lblJaApostou.Text = "—";
            lblJaApostou.ForeColor = Color.White;
            lblJaSorteado.Text = "—";
            lblJaSorteado.ForeColor = Color.White;
            dgvSorteios.DataSource = null;
        }
    }
}
