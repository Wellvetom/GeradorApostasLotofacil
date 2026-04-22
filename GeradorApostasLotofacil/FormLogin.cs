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
    public partial class FormLogin : Form
    {
        public readonly NavigationService _navigationService;
        public event Action OnIrParaCadastro;
        private readonly UsuarioSession _session;
        public event Action<UsuarioModel> OnLoginEfetuado;
        private UsuarioService _usuarioService;
        public FormLogin(NavigationService navigation, UsuarioSession usuarioSession)
        {
            InitializeComponent();
            _navigationService = navigation;
            _session = usuarioSession;
            // 🔥 injeção em cadeia
            var context = new AppDbContext();
            UsuarioRepositoryInterface usuarioRepository = new UsuarioRepository(context);
            _usuarioService = new UsuarioService(usuarioRepository);

        }

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                var login = await _usuarioService.VerificaLogin(txtbox_usuario.Text, txtbox_senha.Text);

                if (login == null)
                    MessageBox.Show("Login incorreto");
                else
                {
                    _session.Login(login);
                    // 🔥 avisa o form principal
                    OnLoginEfetuado?.Invoke(login);

                    _navigationService.NavegarPara(new FormGerarApostas(_navigationService, _session));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("falha na aplicacao", ex.Message);
                throw;
            }
          
        }

        private void linkLbl_nao_possui_cadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _navigationService.NavegarPara(new FormCadastro(_navigationService));

        }
    }
}
