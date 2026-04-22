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
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;

namespace GeradorApostasLotofacil
{
    public partial class FormListarApostas : Form
    {
        public readonly NavigationService _navigationService;
        public readonly UsuarioSession _usuarioSession;
        public readonly ApostaService _apostaService;
        private List<ApostaGridViewModel> apostasBuscadas;
        public FormListarApostas(NavigationService navigationService, UsuarioSession usuarioSession)
        {
            _navigationService = navigationService;
            InitializeComponent();
            var context = new AppDbContext();
            ApostaRepository apostaRepository = new ApostaRepository(context);
            _apostaService = new ApostaService(apostaRepository);
            _usuarioSession = usuarioSession;
            btn_exportarApostas.Visible = false;
        }

        private async void btnListasApostas_Click(object sender, EventArgs e)
        {
            try
            {
                var apostas = await _apostaService.ListarApostas(_usuarioSession.UsuarioLogado.Id);

                if (apostas.Any())
                {
                    apostasBuscadas = apostas.SelectMany(a => a.Jogos.Select(j => new ApostaGridViewModel
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
                    btn_exportarApostas.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("falha na aplicacao", ex.Message);

                throw;
            }


        }

        private void btn_exportarApostas_Click(object sender, EventArgs e)
        {
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
                                      $"{item.DataInclusao:dd/MM/yyyy HH:mm}");
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("CSV exportado com sucesso!");
                }
               
            }
        }
    }
}
