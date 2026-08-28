using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Helper;
using GeradorApostasLotofacil.Session;
using System.Text;

namespace GeradorApostasLotofacil
{
    public partial class FormListarApostas : Form
    {
        private readonly IConferenciaService _conferenciaService;
        private readonly IApostaService _apostaService;
        private readonly UsuarioSession _usuarioSession;
        private List<ApostaGridViewModel>? apostasBuscadas;
        private readonly LoadingPanel _loadingPanel;

        public FormListarApostas(
            IConferenciaService conferenciaService,
            IApostaService apostaService,
            UsuarioSession usuarioSession)
        {
            InitializeComponent();
            _conferenciaService = conferenciaService;
            _apostaService = apostaService;
            _usuarioSession = usuarioSession;
            btn_exportarApostas.Visible = false;

            _loadingPanel = new LoadingPanel();
            this.Controls.Add(_loadingPanel);
        }

        private async void btnListasApostas_Click(object sender, EventArgs e)
        {
            try
            {
                _loadingPanel.Exibir("Buscando apostas...");

                var apostas = await _conferenciaService.ObterApostasComResultado(_usuarioSession.UsuarioLogado.Id);

                if (apostas.Any())
                {
                    apostasBuscadas = apostas.SelectMany(a => a.Jogos.Select(j => new ApostaGridViewModel
                    {
                        Id = j.Id,
                        Numeros = j.Numeros.NumerosList,
                        Acertos = j.Numeros.QuantidadeAcertos,
                        Usuario = _usuarioSession.UsuarioLogado.Username,
                        DataInclusao = a.DataInclusao.ToString("dd/MM/yyyy")
                    })).ToList();

                    dgv_listaApostas.DataSource = apostasBuscadas;
                    dgv_listaApostas.AutoGenerateColumns = false;
                    btn_exportarApostas.Visible = true;
                }

                _loadingPanel.Ocultar();
            }
            catch (Exception ex)
            {
                _loadingPanel.Ocultar();
                MessageBox.Show($"Erro ao listar apostas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exportarApostas_Click(object sender, EventArgs e)
        {
            try
            {
                if (apostasBuscadas == null || !apostasBuscadas.Any())
                {
                    MessageBox.Show("Nenhuma aposta para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Arquivo CSV (*.csv)|*.csv";
                    sfd.FileName = "apostas.csv";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var sb = new StringBuilder();

                        // Cabeçalho
                        sb.AppendLine("Id,PrimeiroNumero,SegundoNumero,TerceiroNumero,QuartoNumero,QuintoNumero,SextoNumero,SetimoNumero,OitavoNumero,NonoNumero,DecimoNumero,DecimoPrimeiroNumero,DecimoSegundoNumero,DecimoTerceiroNumero,DecimoQuartoNumero,DecimoQuintoNumero,Usuario,Data");

                        foreach (var item in apostasBuscadas)
                        {
                            sb.AppendLine($"{item.Id}," +
                                          $"{item.PrimeiroNumero}," +
                                          $"{item.SegundoNumero}," +
                                          $"{item.TerceiroNumero}," +
                                          $"{item.QuartoNumero}," +
                                          $"{item.QuintoNumero}," +
                                          $"{item.SextoNumero}," +
                                          $"{item.SetimoNumero}," +
                                          $"{item.OitavoNumero}," +
                                          $"{item.NonoNumero}," +
                                          $"{item.DecimoNumero}," +
                                          $"{item.DecimoPrimeiroNumero}," +
                                          $"{item.DecimoSegundoNumero}," +
                                          $"{item.DecimoTerceiroNumero}," +
                                          $"{item.DecimoQuartoNumero}," +
                                          $"{item.DecimoQuintoNumero}," +
                                          $"{item.Usuario}," +
                                          $"{item.DataInclusao}");
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("CSV exportado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar CSV: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgv_listaApostas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignora clique no header
            if (e.RowIndex < 0) return;

            // Verifica se é a coluna do botão Resortear
            if (dgv_listaApostas.Columns[e.ColumnIndex].Name != "colResortear") return;

            try
            {
                var aposta = apostasBuscadas?[e.RowIndex];
                if (aposta == null) return;

                var confirmacao = MessageBox.Show(
                    "Deseja resortear esta aposta para o próximo sorteio?",
                    "Confirmar Resortear",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacao != DialogResult.Yes) return;

                _loadingPanel.Exibir("Resorteando aposta...");

                // Busca data do próximo sorteio
                var retornoRobo = await Task.Run(async () =>
                    await new LoteriasCaixaRobot.Interface.BuscaSorteioInterface()
                        .BuscaUltimoSorteio(LoteriasCaixaRobot.Request.BaseRequest.TipoSorteio.Lotofacil));

                // Cria novo registro com os mesmos números
                var novaAposta = new ApostaModel
                {
                    DataInclusao = DateTime.Now,
                    DataApuracao = retornoRobo.DataProximoSorteio,
                    UsuarioId = _usuarioSession.UsuarioLogado!.Id,
                    Jogos = new List<JogoModel>
                    {
                        new JogoModel { Numeros = aposta.Numeros }
                    }
                };

                await _apostaService.GravarApostas(novaAposta);

                _loadingPanel.Ocultar();
                MessageBox.Show(
                    $"Aposta resorteada com sucesso!\nPróximo sorteio: {retornoRobo.DataProximoSorteio:dd/MM/yyyy}",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _loadingPanel.Ocultar();
                MessageBox.Show($"Erro ao resortear: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
