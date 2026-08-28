using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Helper;
using GeradorApostasLotofacil.Session;
using System.Text;

namespace GeradorApostasLotofacil
{
    public partial class FormListarApostas : Form
    {
        private readonly IConferenciaService _conferenciaService;
        private readonly UsuarioSession _usuarioSession;
        private List<ApostaGridViewModel>? apostasBuscadas;

        public FormListarApostas(
            IConferenciaService conferenciaService,
            UsuarioSession usuarioSession)
        {
            InitializeComponent();
            _conferenciaService = conferenciaService;
            _usuarioSession = usuarioSession;
            btn_exportarApostas.Visible = false;
        }

        private async void btnListasApostas_Click(object sender, EventArgs e)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
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
    }
}
