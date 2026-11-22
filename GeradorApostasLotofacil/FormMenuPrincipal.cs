using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Session;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;

namespace GeradorApostasLotofacil
{
    public partial class FormMenuPrincipal : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HL_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private readonly UsuarioSession _session;
        private readonly LoteriaConfig _config;
        private NavigationService _navigationService = null!;
        private IServiceProvider _serviceProvider = null!;

        public FormMenuPrincipal(UsuarioSession session, LoteriaConfig config)
        {
            InitializeComponent();
            _session = session;
            _config = config;
            label1.Text = $"🎯 Gerador de Apostas {_config.Nome}";
            Text = $"Gerador de Apostas {_config.Nome}";
            linklogoff.Enabled = false;
            linklogoff.Visible = false;
            btn_restaurar.Visible = false;
            btn_FormIncluirAposta.Visible = false;
            btn_FormListarApostas.Visible = false;
            btn_FormVerificarAposta.Visible = false;
            btn_ImportarApostas.Visible = false;
            btn_Dashboard.Visible = false;
            btn_DashboardAdmin.Visible = false;
        }

        public void InitializeNavigation(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _navigationService = new NavigationService(panel_formularios, serviceProvider);
        }

        /// <summary>
        /// Prepara este form para ser embutido como conteúdo de uma aba (TabPage),
        /// ocultando a própria barra de título (janela) já que o shell externo a fornece.
        /// </summary>
        public void PrepararComoAba()
        {
            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;
            panel_principal.Visible = false; // esconde a barra de título interna
        }

        /// <summary>Reaplica o estado de UI de login (usado quando o login é feito por outra aba).</summary>
        public void AplicarEstadoLogin()
        {
            if (_session.UsuarioLogado == null) return;
            MarcarLogado(_session.UsuarioLogado);
        }

        private void MarcarLogado(UsuarioModel usuario)
        {
            btnFormLoginCadastro.Font = new Font("Segoe UI", 10F);
            btnFormLoginCadastro.ForeColor = Color.FromArgb(130, 200, 130);
            btnFormLoginCadastro.Text = $"👤 {usuario.Username}";
            btnFormLoginCadastro.Enabled = false;
            btn_FormIncluirAposta.Visible = true;
            btn_FormListarApostas.Visible = true;
            btn_FormVerificarAposta.Visible = true;
            btn_Dashboard.Visible = true;
            if (usuario.Perfil.Equals("Administrador") || usuario.Perfil.Equals("Admin"))
            {
                btn_ImportarApostas.Visible = true;
                btn_DashboardAdmin.Visible = true;
            }
            linklogoff.Visible = true;
            linklogoff.Enabled = true;
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.btn_restaurar.Visible = true;
            btn_maximizar.Visible = false;
        }

        private void btn_restaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btn_restaurar.Visible = false;
            btn_maximizar.Visible = true;
        }

        private void panel_principal_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HL_CAPTION, 0);
            }
        }

        private void AbrirLogin()
        {
            var login = _serviceProvider.GetRequiredService<FormLogin>();

            login.OnLoginEfetuado += (usuario) =>
            {
                MarcarLogado(usuario);
                LoginEfetuado?.Invoke(usuario);
            };

            _navigationService.NavegarPara(login);
        }

        /// <summary>Disparado quando o login é efetuado nesta aba (permite o shell sincronizar as demais).</summary>
        public event Action<UsuarioModel>? LoginEfetuado;

        /// <summary>Disparado quando o logoff é efetuado nesta aba.</summary>
        public event Action? LogoffEfetuado;

        private void btnFormLoginCadastro_Click(object sender, EventArgs e)
        {
            AbrirLogin();
        }

        private void btn_incluirAposta_Click(object sender, EventArgs e)
        {
            _navigationService.NavegarPara<FormGerarApostas>();
        }

        private void linklogoff_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _session.Logout();
            ResetarUiLogin();
            _navigationService.NavegarPara<FormLogin>();
            LogoffEfetuado?.Invoke();
        }

        /// <summary>Restaura a UI para o estado deslogado (sem disparar eventos).</summary>
        public void ResetarUiLogin()
        {
            btnFormLoginCadastro.Font = new Font("Segoe UI", 11F);
            btnFormLoginCadastro.ForeColor = Color.FromArgb(210, 210, 230);
            btnFormLoginCadastro.Text = "🔐  Login / Cadastro";
            btnFormLoginCadastro.Enabled = true;
            linklogoff.Enabled = false;
            linklogoff.Visible = false;
            btn_FormIncluirAposta.Visible = false;
            btn_FormListarApostas.Visible = false;
            btn_FormVerificarAposta.Visible = false;
            btn_ImportarApostas.Visible = false;
            btn_Dashboard.Visible = false;
            btn_DashboardAdmin.Visible = false;
        }

        /// <summary>Navega esta aba para a tela de login (usado pelo shell ao sincronizar logoff).</summary>
        public void IrParaLogin()
        {
            _navigationService.NavegarPara<FormLogin>();
        }

        private void btn_FormListarApostas_Click(object sender, EventArgs e)
        {
            _navigationService.NavegarPara<FormListarApostas>();
        }

        private void btn_FormVerificarAposta_Click(object sender, EventArgs e)
        {
            _navigationService.NavegarPara<FormVerificarAposta>();
        }

        private void btn_ImportarApostas_Click(object sender, EventArgs e)
        {
            _navigationService.NavegarPara<FormImportarApostas>();
        }

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            _navigationService.NavegarPara<FormDashboard>();
        }

        private void btn_DashboardAdmin_Click(object sender, EventArgs e)
        {
            _navigationService.NavegarPara<FormDashboardAdmin>();
        }
    }
}
