using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Helper;
using GeradorApostasLotofacil.Infrastructure;
using GeradorApostasLotofacil.Repository;
using GeradorApostasLotofacil.Session;
using LoteriasCaixaRobot.Interface;
using LoteriasCaixaRobot.Result;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeradorApostasLotofacil
{
    public partial class FormImportarApostas : Form
    {
        public readonly NavigationService _navigationService;
        public readonly UsuarioSession _usuarioSession;
        public readonly ApostaService _apostaService;
        public FormImportarApostas(NavigationService navigationService, UsuarioSession usuarioSession)
        {
            _navigationService = navigationService;
            InitializeComponent();
            var context = new AppDbContext();
            ApostaRepository apostaRepository = new ApostaRepository(context);
            _apostaService = new ApostaService(apostaRepository);
            _usuarioSession = usuarioSession;
            CarregarDados();
            CarregaUltimasApostas();
        }

        private async void btn_importarApostas_Click(object sender, EventArgs e)
        {
            await _apostaService.ImportarApostas();
        }
        private async void CarregarDados()
        {
            var retornoRobo = await new LoteriasCaixaRobot.Interface.BuscaSorteioInterface().BuscaUltimoSorteio(LoteriasCaixaRobot.Request.BaseRequest.TipoSorteio.Lotofacil);

            if (retornoRobo.ProcessOK)
            {
                label_dadosApostas.Text = $"Ultimo sorteio realizado em: {retornoRobo.DataUltimoSorteio.ToString("dd/MM/yyyy")}\nO proximo sorteio será realizado em: {retornoRobo.DataProximoSorteio.ToString("dd/MM/yyyy")} ";
            }

        }
        private async void CarregaUltimasApostas()
        {
            var apostas = await _apostaService.ObterUltimas10();

            if (apostas.Any())
            {
                var apostasBuscadas = apostas.SelectMany(a => a.Jogos.Select(j => new ApostaGridViewModel
                {
                    Id = j.Id,
                    PrimeiroNumero = j.PrimeiroNumero,
                    SegundoNumero = j.SegundoNumero,
                    TerceiroNumero = j.TerceiroNumero,
                    QuartoNumero = j.QuartoNumero,
                    QuintoNumero = j.QuintoNumero,
                    SextoNumero = j.SextoNumero,
                    SetimoNumero = j.SetimoNumero,
                    OitavoNumero = j.OitavoNumero,
                    NonoNumero = j.NonoNumero,
                    DecimoNumero = j.DecimoNumero,
                    DecimoPrimeiroNumero = j.DecimoPrimeiroNumero,
                    DecimoSegundoNumero = j.DecimoSegundoNumero,
                    DecimoTerceiroNumero = j.DecimoTerceiroNumero,
                    DecimoQuartoNumero = j.DecimoQuartoNumero,
                    DecimoQuintoNumero = j.DecimoQuintoNumero,

                    Usuario = _usuarioSession.UsuarioLogado.Username,

                    DataInclusao = a.DataInclusao.ToString("dd/MM/yyyy")
                })).ToList();

                dgv_listaApostas.DataSource = apostasBuscadas;
                dgv_listaApostas.AutoGenerateColumns = false;
            }
        }

    }
}
