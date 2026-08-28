using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.DTO;
using GeradorApostasLotofacil.Helper;
using GeradorApostasLotofacil.Session;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Text;

namespace GeradorApostasLotofacil
{
    public partial class FormListarApostas : Form
    {
        private readonly IConferenciaService _conferenciaService;
        private readonly IApostaService _apostaService;
        private readonly UsuarioSession _usuarioSession;
        private List<ApostaGridViewModel>? apostasBuscadas;
        private List<ApostaResultadoViewModel>? _apostasOriginais;
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
            btn_exportarPdf.Visible = false;

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
                    _apostasOriginais = apostas;

                    var dataDe = dtpDe.Value.Date;
                    var dataAte = dtpAte.Value.Date.AddDays(1).AddTicks(-1);

                    apostasBuscadas = apostas
                        .Where(a => a.DataInclusao >= dataDe && a.DataInclusao <= dataAte)
                        .SelectMany(a => a.Jogos.Select(j => new ApostaGridViewModel
                        {
                            Id = j.Id,
                            ApostaId = a.Id,
                            Numeros = j.Numeros.NumerosList,
                            Acertos = j.Numeros.QuantidadeAcertos,
                            Usuario = _usuarioSession.UsuarioLogado.Username,
                            DataInclusao = a.DataInclusao.ToString("dd/MM/yyyy")
                        })).ToList();

                    dgv_listaApostas.DataSource = apostasBuscadas;
                    dgv_listaApostas.AutoGenerateColumns = false;
                    btn_exportarApostas.Visible = true;
                    btn_exportarPdf.Visible = true;
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

            var columnName = dgv_listaApostas.Columns[e.ColumnIndex].Name;

            if (columnName == "colResortear")
            {
                await ResortearAposta(e.RowIndex);
            }
            else if (columnName == "colDuplicar")
            {
                await DuplicarAposta(e.RowIndex);
            }
            else if (columnName == "colExcluir")
            {
                await ExcluirAposta(e.RowIndex);
            }
        }

        private async Task ResortearAposta(int rowIndex)
        {
            try
            {
                var aposta = apostasBuscadas?[rowIndex];
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

        private async Task DuplicarAposta(int rowIndex)
        {
            try
            {
                var jogoClicado = apostasBuscadas?[rowIndex];
                if (jogoClicado == null || _apostasOriginais == null) return;

                // Busca a aposta original com todos os jogos
                var apostaOriginal = _apostasOriginais.FirstOrDefault(a => a.Id == jogoClicado.ApostaId);
                if (apostaOriginal == null)
                {
                    MessageBox.Show("Aposta original não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var totalJogos = apostaOriginal.Jogos.Count;
                var confirmacao = MessageBox.Show(
                    $"Deseja duplicar esta aposta ({totalJogos} jogo{(totalJogos > 1 ? "s" : "")}) para o próximo sorteio?",
                    "Confirmar Duplicar Aposta",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacao != DialogResult.Yes) return;

                _loadingPanel.Exibir("Duplicando aposta...");

                // Busca data do próximo sorteio via robô
                var retornoRobo = await Task.Run(async () =>
                    await new LoteriasCaixaRobot.Interface.BuscaSorteioInterface()
                        .BuscaUltimoSorteio(LoteriasCaixaRobot.Request.BaseRequest.TipoSorteio.Lotofacil));

                // Cria nova aposta com TODOS os jogos da aposta original
                var novaAposta = new ApostaModel
                {
                    DataInclusao = DateTime.Now,
                    DataApuracao = retornoRobo.DataProximoSorteio,
                    UsuarioId = _usuarioSession.UsuarioLogado!.Id,
                    Jogos = apostaOriginal.Jogos.Select(j => new JogoModel
                    {
                        Numeros = new List<int>(j.Numeros.NumerosList)
                    }).ToList()
                };

                await _apostaService.GravarApostas(novaAposta);

                _loadingPanel.Ocultar();
                MessageBox.Show(
                    $"Aposta duplicada com sucesso!\n{totalJogos} jogo{(totalJogos > 1 ? "s" : "")} copiado{(totalJogos > 1 ? "s" : "")} para o próximo sorteio: {retornoRobo.DataProximoSorteio:dd/MM/yyyy}",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _loadingPanel.Ocultar();
                MessageBox.Show($"Erro ao duplicar aposta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ExcluirAposta(int rowIndex)
        {
            try
            {
                var jogoClicado = apostasBuscadas?[rowIndex];
                if (jogoClicado == null) return;

                var confirmacao = MessageBox.Show(
                    "Deseja excluir esta aposta? Esta ação não pode ser desfeita.",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacao != DialogResult.Yes) return;

                _loadingPanel.Exibir("Excluindo aposta...");

                await _apostaService.ExcluirAposta(jogoClicado.Id);

                _loadingPanel.Ocultar();
                MessageBox.Show("Aposta excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recarrega a lista
                btnListasApostas_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                _loadingPanel.Ocultar();
                MessageBox.Show($"Erro ao excluir aposta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exportarPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (apostasBuscadas == null || !apostasBuscadas.Any())
                {
                    MessageBox.Show("Nenhuma aposta para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var sfd = new SaveFileDialog();
                sfd.Filter = "Arquivo PDF (*.pdf)|*.pdf";
                sfd.FileName = $"apostas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                QuestPDF.Settings.License = LicenseType.Community;

                var usuario = _usuarioSession.UsuarioLogado?.Username ?? "Usuário";

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4.Landscape());
                        page.Margin(30);
                        page.DefaultTextStyle(x => x.FontSize(9));

                        // Header
                        page.Header().Column(col =>
                        {
                            col.Item().Text("Gerador de Apostas Lotofácil")
                                .FontSize(18).Bold().FontColor(Colors.Blue.Darken2);
                            col.Item().Text($"Apostas de: {usuario}  |  Exportado em: {DateTime.Now:dd/MM/yyyy HH:mm}")
                                .FontSize(10).FontColor(Colors.Grey.Darken1);
                            col.Item().PaddingBottom(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                        });

                        // Conteúdo - tabela de apostas
                        page.Content().Table(table =>
                        {
                            // Definir colunas: Data + 15 números + Acertos
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2); // Data
                                for (int i = 0; i < 15; i++)
                                    columns.RelativeColumn(1); // Números
                                columns.RelativeColumn(1.5f); // Acertos
                            });

                            // Header da tabela
                            table.Header(header =>
                            {
                                header.Cell().Element(CellHeaderStyle).Text("Data");
                                for (int i = 1; i <= 15; i++)
                                    header.Cell().Element(CellHeaderStyle).Text($"{i}º");
                                header.Cell().Element(CellHeaderStyle).Text("Acertos");
                            });

                            // Linhas de dados
                            foreach (var item in apostasBuscadas)
                            {
                                table.Cell().Element(CellStyle).Text(item.DataInclusao);
                                table.Cell().Element(CellStyle).Text(item.PrimeiroNumero.ToString("D2"));
                                table.Cell().Element(CellStyle).Text(item.SegundoNumero.ToString("D2"));
                                table.Cell().Element(CellStyle).Text(item.TerceiroNumero.ToString("D2"));
                                table.Cell().Element(CellStyle).Text(item.QuartoNumero.ToString("D2"));
                                table.Cell().Element(CellStyle).Text(item.QuintoNumero.ToString("D2"));
                                table.Cell().Element(CellStyle).Text(item.SextoNumero.ToString("D2"));
                                table.Cell().Element(CellStyle).Text(item.SetimoNumero.ToString("D2"));
                                table.Cell().Element(CellStyle).Text(item.OitavoNumero.ToString("D2"));
                                table.Cell().Element(CellStyle).Text(item.NonoNumero.ToString("D2"));
                                table.Cell().Element(CellStyle).Text(item.DecimoNumero.ToString("D2"));
                                table.Cell().Element(CellStyle).Text(item.DecimoPrimeiroNumero.ToString("D2"));
                                table.Cell().Element(CellStyle).Text(item.DecimoSegundoNumero.ToString("D2"));
                                table.Cell().Element(CellStyle).Text(item.DecimoTerceiroNumero.ToString("D2"));
                                table.Cell().Element(CellStyle).Text(item.DecimoQuartoNumero.ToString("D2"));
                                table.Cell().Element(CellStyle).Text(item.DecimoQuintoNumero.ToString("D2"));
                                table.Cell().Element(CellStyle).Text(item.Acertos > 0 ? item.Acertos.ToString() : "—");
                            }
                        });

                        // Footer
                        page.Footer().AlignCenter().Text(text =>
                        {
                            text.Span("Página ");
                            text.CurrentPageNumber();
                            text.Span(" de ");
                            text.TotalPages();
                        });
                    });
                }).GeneratePdf(sfd.FileName);

                MessageBox.Show("PDF exportado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar PDF: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static IContainer CellHeaderStyle(IContainer container)
        {
            return container
                .Background(Colors.Blue.Darken2)
                .Padding(4)
                .AlignCenter()
                .AlignMiddle()
                .DefaultTextStyle(x => x.FontColor(Colors.White).Bold().FontSize(8));
        }

        private static IContainer CellStyle(IContainer container)
        {
            return container
                .BorderBottom(1)
                .BorderColor(Colors.Grey.Lighten2)
                .Padding(4)
                .AlignCenter()
                .AlignMiddle();
        }
    }
}
