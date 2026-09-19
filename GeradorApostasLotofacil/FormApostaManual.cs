using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.DTO;
using GeradorApostasLotofacil.Session;

namespace GeradorApostasLotofacil
{
    public partial class FormApostaManual : Form
    {
        private readonly IConferenciaService _conferenciaService;
        private readonly IApostaService _apostaService;
        private readonly IGeracaoService _geracaoService;
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

        public FormApostaManual(
            IConferenciaService conferenciaService,
            IApostaService apostaService,
            IGeracaoService geracaoService,
            UsuarioSession usuarioSession)
        {
            InitializeComponent();
            _conferenciaService = conferenciaService;
            _apostaService = apostaService;
            _geracaoService = geracaoService;
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
                $"Selecione 15 números (1 a 25).  Selecionados: {selecionados}/{NumerosPorAposta}";

            // Habilita Verificar/Gravar apenas quando exatamente 15 estão marcados.
            bool completo = selecionados == NumerosPorAposta;
            btnVerificar.Enabled = completo;
            btnGravar.Enabled = completo;
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

        private async void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_usuarioSession.UsuarioLogado == null)
                {
                    MessageBox.Show("Sessão expirada. Faça login novamente para gravar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var numeros = ObterNumerosSelecionados();

                if (numeros.Count != NumerosPorAposta)
                {
                    MessageBox.Show($"Selecione exatamente {NumerosPorAposta} números.",
                        "Seleção incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _loadingPanel.Exibir("Gravando aposta...");

                // Busca o próximo sorteio para associar a data de apuração (mesmo padrão da geração automática).
                var retornoRobo = await new LoteriasCaixaRobot.Interface.BuscaSorteioInterface()
                    .BuscaUltimoSorteio(LoteriasCaixaRobot.Request.BaseRequest.TipoSorteio.Lotofacil);

                var dataApuracao = retornoRobo.DataProximoSorteio;
                var jogosNumeros = new List<List<int>> { numeros };

                bool duplicada = await _apostaService.ExisteApostaDuplicada(
                    _usuarioSession.UsuarioLogado.Id,
                    dataApuracao,
                    jogosNumeros);

                _loadingPanel.Ocultar();

                if (duplicada)
                {
                    var confirmacao = MessageBox.Show(
                        "Você já gravou uma aposta idêntica para este sorteio.\n\nDeseja gravar novamente mesmo assim?",
                        "Aposta duplicada",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmacao != DialogResult.Yes)
                        return;
                }

                _loadingPanel.Exibir("Gravando aposta...");

                var aposta = new ApostaModel
                {
                    Jogos = new List<JogoModel>
                    {
                        new JogoModel { Numeros = numeros }
                    },
                    DataInclusao = DateTime.Now,
                    DataApuracao = dataApuracao,
                    UsuarioId = _usuarioSession.UsuarioLogado.Id
                };

                await _apostaService.GravarApostas(aposta);

                _loadingPanel.Ocultar();
                MessageBox.Show("Aposta gravada com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _loadingPanel.Ocultar();
                MessageBox.Show($"Erro ao gravar aposta: {ex.Message}", "Erro",
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

            // Card 3: melhor resultado (acertos × números não sorteados)
            if (r.MelhorAcerto < 0)
            {
                lblMelhorResultado.ForeColor = Color.FromArgb(210, 210, 230);
                lblMelhorResultado.Text = "❌ Não há sorteios oficiais importados para comparar.";
            }
            else
            {
                lblMelhorResultado.ForeColor = Color.FromArgb(255, 210, 140);
                var origem = r.MelhorConcurso > 0 ? $"concurso {r.MelhorConcurso}" : "sorteio";
                var data = r.MelhorData?.ToString("dd/MM/yyyy");
                var complemento = data != null ? $" ({origem} — {data})" : $" ({origem})";
                lblMelhorResultado.Text =
                    $"🎯 {r.MelhorAcerto} acertos · {r.NaoSorteados} não sorteados{complemento}";
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

        private async void btnGerarAuto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PerguntarCriterio(out int acertosAlvo, out int minSorteios))
                    return; // usuário cancelou

                _loadingPanel.Exibir("Gerando jogo automático...");

                // A geração é uma busca que pode iterar bastante; roda fora da UI thread.
                var numeros = await Task.Run(() =>
                    _geracaoService.GerarJogoComCriterio(acertosAlvo, minSorteios));

                PreencherToggles(numeros);
                AtualizarContador();

                _loadingPanel.Ocultar();

                MessageBox.Show(
                    $"Jogo inédito gerado com sucesso!\n\nNúmeros: {string.Join(" - ", numeros.Select(n => n.ToString("D2")))}\n\n" +
                    $"Critério: pelo menos {acertosAlvo} acertos em {minSorteios} sorteio(s) já ocorrido(s).\n\n" +
                    "Clique em Verificar para conferir o histórico completo ou em Gravar para salvar.",
                    "Jogo gerado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _loadingPanel.Ocultar();
                MessageBox.Show(ex.Message, "Não foi possível gerar",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>Marca nos toggles exatamente os números informados (limpa os demais).</summary>
        private void PreencherToggles(List<int> numeros)
        {
            var alvo = numeros.ToHashSet();
            foreach (var btn in _botoes)
            {
                bool selecionar = alvo.Contains(int.Parse(btn.Text));
                Selecionar(btn, selecionar);
            }
        }

        /// <summary>
        /// Diálogo modal que pergunta o alvo de acertos (11 a 14) e a quantidade mínima
        /// de sorteios já ocorridos que devem atingir esse alvo.
        /// </summary>
        private bool PerguntarCriterio(out int acertosAlvo, out int minSorteios)
        {
            acertosAlvo = 11;
            minSorteios = 1;

            using var dlg = new Form
            {
                Text = "Gerar jogo automático",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = new Size(420, 210),
                BackColor = Color.FromArgb(37, 38, 54)
            };

            var lblAlvo = new Label
            {
                Text = "Quantidade de acertos por sorteio:",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 20),
                AutoSize = true
            };
            var cmbAlvo = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(20, 48),
                Size = new Size(120, 28),
                Font = new Font("Segoe UI", 10F)
            };
            cmbAlvo.Items.AddRange(new object[] { 11, 12, 13, 14 });
            cmbAlvo.SelectedIndex = 0;

            var lblQtd = new Label
            {
                Text = "Em quantos sorteios já ocorridos:",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 90),
                AutoSize = true
            };
            var numQtd = new NumericUpDown
            {
                Location = new Point(20, 118),
                Size = new Size(120, 28),
                Font = new Font("Segoe UI", 10F),
                Minimum = 1,
                Maximum = 10000,
                Value = 1
            };

            var btnOk = new Button
            {
                Text = "Gerar",
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(215, 160),
                Size = new Size(90, 34)
            };
            btnOk.FlatAppearance.BorderSize = 0;

            var btnCancelar = new Button
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                BackColor = Color.FromArgb(70, 75, 95),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(315, 160),
                Size = new Size(90, 34)
            };
            btnCancelar.FlatAppearance.BorderSize = 0;

            dlg.Controls.AddRange(new Control[] { lblAlvo, cmbAlvo, lblQtd, numQtd, btnOk, btnCancelar });
            dlg.AcceptButton = btnOk;
            dlg.CancelButton = btnCancelar;

            if (dlg.ShowDialog(this) != DialogResult.OK)
                return false;

            acertosAlvo = (int)cmbAlvo.SelectedItem!;
            minSorteios = (int)numQtd.Value;
            return true;
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
            lblMelhorResultado.Text = "—";
            lblMelhorResultado.ForeColor = Color.White;
            dgvSorteios.DataSource = null;
        }
    }
}
