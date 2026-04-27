using GeradorApostasLotofacil.Application;
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
        }

        private void btn_importarApostas_Click(object sender, EventArgs e)
        {

        }
        private async void CarregarDados()
        {
            var retornoRobo = await new LoteriasCaixaRobot.Interface.BuscaSorteioInterface().BuscaUltimoSorteio(LoteriasCaixaRobot.Request.BaseRequest.TipoSorteio.Lotofacil);

            if (retornoRobo.ProcessOK)
            {
                label_dadosApostas.Text = $"Ultimo sorteio realizado em: {retornoRobo.DataUltimoSorteio.ToString("dd/MM/yyyy")}";
            }

        }
    }
}
