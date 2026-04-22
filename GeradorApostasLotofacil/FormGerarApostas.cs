using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Infrastructure;
using GeradorApostasLotofacil.Repository;
using GeradorApostasLotofacil.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeradorApostasLotofacil
{
    public partial class FormGerarApostas : Form
    {
        public readonly NavigationService _navigationService;
        public readonly UsuarioSession _usuarioSession;
        public readonly ApostaService _apostaService;
        public List<JogoModel> _jogosSalvos;
        public FormGerarApostas(NavigationService navigationService, UsuarioSession usuarioSession)
        {


            _navigationService = navigationService;
            InitializeComponent();
            var context = new AppDbContext();
            ApostaRepository apostaRepository = new ApostaRepository(context);
            _apostaService = new ApostaService(apostaRepository);
            _usuarioSession = usuarioSession;

        }

        private async void btn_gerarApostas_Click(object sender, EventArgs e)
        {
            try
            {
                var apostas = _apostaService.GerarApostas(numberBox_quantidadeApostas.Value, radioBtn_apostasIneditas.Checked);

                if (apostas.Jogos.Any())
                {
                    _jogosSalvos = apostas.Jogos;
                    dgv_listaApostas.AutoGenerateColumns = false;
                    dgv_listaApostas.DataSource = apostas.Jogos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("falha na aplicacao", ex.Message);

                throw;
            }
           
        }

        private async void btnGravarApostas_Click(object sender, EventArgs e)
        {
            try
            {
                var aposta = new ApostaModel() { Jogos = _jogosSalvos, DataInclusao = DateTime.Now, UsuarioId = _usuarioSession.UsuarioLogado.Id };
                await _apostaService.GravarApostas(aposta);
                MessageBox.Show("Apostas gravadas com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("falha na aplicacao", ex.Message);

                throw;
            }
            
        }
    }
}
