using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Infrastructure;
using GeradorApostasLotofacil.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeradorApostasLotofacil
{
    public partial class FormCadastro : Form
    {
        private readonly NavigationService _navigationService;
        private UsuarioService _usuarioService;
        public FormCadastro(NavigationService navigation)
        {
            InitializeComponent();
            _navigationService = navigation;
            var context = new AppDbContext();
            UsuarioRepositoryInterface usuarioRepository = new UsuarioRepository(context);
            _usuarioService = new UsuarioService(usuarioRepository);
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            var usuario = txtbox_usuario.Text;
            var senha = maskedtxtbox_senha.Text;
            var email = txtbox_Email.Text;
            var perfil = cmbBox_Perfil.SelectedItem.ToString();

            _usuarioService.CadastrarUsuario(usuario, senha, email, perfil);
            MessageBox.Show("Usuario cadastrado com sucesso!");
            _navigationService.NavegarPara(new FormLogin(_navigationService, new Session.UsuarioSession()));

            //Envia para Application
        }
    }
}
