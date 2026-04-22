using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Helper;
using GeradorApostasLotofacil.Infrastructure;
using GeradorApostasLotofacil.Repository;
using GeradorApostasLotofacil.Session;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeradorApostasLotofacil
{
    public partial class FormListarApostas : Form
    {
        public readonly NavigationService _navigationService;
        public readonly UsuarioSession _usuarioSession;
        public readonly ApostaService _apostaService;
        public FormListarApostas(NavigationService navigationService, UsuarioSession usuarioSession)
        {
            _navigationService = navigationService;
            InitializeComponent();
            var context = new AppDbContext();
            ApostaRepository apostaRepository = new ApostaRepository(context);
            _apostaService = new ApostaService(apostaRepository);
            _usuarioSession = usuarioSession;
        }

        private async void btnListasApostas_Click(object sender, EventArgs e)
        {
            try
            {
                var apostas = await _apostaService.ListarApostas(_usuarioSession.UsuarioLogado.Id);

                if (apostas.Any())
                {

                    var listagem = apostas

                             .SelectMany(a => a.Jogos.Select(j => new
                             {
                                 j.Id,

                                 j.PrimeiroNumero,
                                 j.SegundoNumero,
                                 j.TerceiroNumero,
                                 j.QuartoNumero,
                                 j.QuintoNumero,
                                 j.SextoNumero,
                                 j.SetimoNumero,
                                 j.OitavoNumero,
                                 j.NonoNumero,
                                 j.DecimoNumero,
                                 j.DecimoPrimeiroNumero,
                                 j.DecimoSegundoNumero,
                                 j.DecimoTerceiroNumero,
                                 j.DecimoQuartoNumero,
                                 j.DecimoQuintoNumero,

                                 Usuario = _usuarioSession.UsuarioLogado.Username,

                                 DataInclusao = a.DataInclusao.ToString("dd/MM/yyyy")
                             }))
                             .ToList();
                    dgv_listaApostas.DataSource = listagem;
                    dgv_listaApostas.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("falha na aplicacao", ex.Message);

                throw;
            }


        }
    }
}
