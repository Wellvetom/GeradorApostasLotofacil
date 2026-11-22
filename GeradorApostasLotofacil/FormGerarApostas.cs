using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Session;
using Microsoft.Extensions.DependencyInjection;

namespace GeradorApostasLotofacil
{
    public partial class FormGerarApostas : Form
    {
        private readonly IGeracaoService _geracaoService;
        private readonly IApostaService _apostaService;
        private readonly UsuarioSession _usuarioSession;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICaixaLoteriaClient _caixa;
        private readonly LoteriaConfig _config;
        private List<JogoModel>? _jogosSalvos;
        private readonly LoadingPanel _loadingPanel;

        public FormGerarApostas(
            IGeracaoService geracaoService,
            IApostaService apostaService,
            UsuarioSession usuarioSession,
            IServiceProvider serviceProvider,
            ICaixaLoteriaClient caixa,
            LoteriaConfig config)
        {
            InitializeComponent();
            _geracaoService = geracaoService;
            _apostaService = apostaService;
            _usuarioSession = usuarioSession;
            _serviceProvider = serviceProvider;
            _caixa = caixa;
            _config = config;

            ConfigurarLimitesPorModalidade();

            _loadingPanel = new LoadingPanel();
            this.Controls.Add(_loadingPanel);
        }

        /// <summary>
        /// Ajusta os limites e valores iniciais dos controles de geração de acordo
        /// com a modalidade (ex.: Lotofácil usa 15 números por jogo, Mega Sena usa 6).
        /// Evita que os máximos/valores padrão (fixos no Designer para a Lotofácil)
        /// extrapolem o tamanho do jogo da modalidade atual.
        /// </summary>
        private void ConfigurarLimitesPorModalidade()
        {
            int numerosPorJogo = _config.NumerosPorJogo;

            // O máximo de "mais" ou "menos" sorteados nunca pode passar do tamanho do jogo.
            numMaisSorteados.Maximum = numerosPorJogo;
            numMenosSorteados.Maximum = numerosPorJogo;

            // Defaults proporcionais, garantindo que a soma não ultrapasse o jogo e
            // ainda sobre pelo menos 1 número aleatório quando houver espaço.
            // Lotofácil (15): mais=10, menos=2, aleatórios=3.
            // Mega Sena (6):  mais=4,  menos=1, aleatórios=1.
            int maisPadrao = Math.Max(0, (int)Math.Round(numerosPorJogo * 2.0 / 3.0));
            int menosPadrao = numerosPorJogo >= 6 ? Math.Max(1, numerosPorJogo / 6) : 0;

            // Garante que sobre ao menos 1 aleatório quando o jogo comporta.
            if (numerosPorJogo >= 2 && maisPadrao + menosPadrao >= numerosPorJogo)
                maisPadrao = Math.Max(0, numerosPorJogo - menosPadrao - 1);

            numMaisSorteados.Value = Math.Min(maisPadrao, numMaisSorteados.Maximum);
            numMenosSorteados.Value = Math.Min(menosPadrao, numMenosSorteados.Maximum);

            // Atualiza o indicador de aleatórios para refletir os novos valores.
            numMaisMenos_ValueChanged(numMaisSorteados, EventArgs.Empty);
        }

        private void btnCriarManual_Click(object sender, EventArgs e)
        {
            using var form = _serviceProvider.GetRequiredService<FormApostaManual>();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
        }

        private void btn_gerarApostas_Click(object sender, EventArgs e)
        {
            try
            {
                int maisSorteados = (int)numMaisSorteados.Value;
                int menosSorteados = (int)numMenosSorteados.Value;

                if (maisSorteados + menosSorteados > _config.NumerosPorJogo)
                {
                    MessageBox.Show($"A soma dos mais sorteados + menos sorteados não pode ultrapassar {_config.NumerosPorJogo}.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var apostas = _geracaoService.GerarJogosInteligentes(
                    numberBox_quantidadeApostas.Value,
                    maisSorteados,
                    menosSorteados);

                if (apostas.Jogos.Any())
                {
                    _jogosSalvos = apostas.Jogos;
                    dgv_listaApostas.AutoGenerateColumns = false;

                    var displayList = apostas.Jogos.Select(j => new Helper.ApostaGridViewModel
                    {
                        Numeros = j.Numeros
                    }).ToList();

                    dgv_listaApostas.DataSource = displayList;

                    // Novos jogos gerados: reabilita a gravação.
                    btnGravarApostas.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar apostas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGravarApostas_Click(object sender, EventArgs e)
        {
            try
            {
                if (_jogosSalvos == null || !_jogosSalvos.Any())
                {
                    MessageBox.Show("Nenhuma aposta gerada para gravar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_usuarioSession.UsuarioLogado == null)
                {
                    MessageBox.Show("Sessão expirada. Faça login novamente para gravar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _loadingPanel.Exibir("Gravando apostas...");

                var ultimoSorteio = await _caixa.ObterUltimoAsync();

                var dataApuracao = ultimoSorteio.DataProximoSorteio;
                var jogosNumeros = _jogosSalvos.Select(j => j.Numeros).ToList();

                // Validação de negócio: já existe esse mesmo lote de jogos gravado
                // para este usuário e este sorteio?
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

                _loadingPanel.Exibir("Gravando apostas...");

                var aposta = new ApostaModel()
                {
                    Jogos = _jogosSalvos,
                    DataInclusao = DateTime.Now,
                    DataApuracao = dataApuracao,
                    UsuarioId = _usuarioSession.UsuarioLogado.Id
                };

                await _apostaService.GravarApostas(aposta);

                _loadingPanel.Ocultar();
                MessageBox.Show("Apostas gravadas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Prevenção de gravação duplicada acidental: limpa o estado e
                // desabilita o botão até que novos jogos sejam gerados.
                _jogosSalvos = null;
                dgv_listaApostas.DataSource = null;
                btnGravarApostas.Enabled = false;
            }
            catch (Exception ex)
            {
                _loadingPanel.Ocultar();
                MessageBox.Show($"Erro ao gravar apostas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numMaisMenos_ValueChanged(object? sender, EventArgs e)
        {
            int mais = (int)numMaisSorteados.Value;
            int menos = (int)numMenosSorteados.Value;
            int total = _config.NumerosPorJogo;
            int aleatorios = total - mais - menos;

            if (aleatorios < 0)
            {
                // Ajusta automaticamente para não ultrapassar o tamanho do jogo
                if (sender == numMaisSorteados)
                    numMaisSorteados.Value = total - menos;
                else
                    numMenosSorteados.Value = total - mais;

                aleatorios = 0;
            }

            label_aleatorios.Text = $"🎲 Aleatórios: {aleatorios}";
        }
    }
}
