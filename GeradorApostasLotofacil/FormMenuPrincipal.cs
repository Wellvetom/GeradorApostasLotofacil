using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Session;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
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
        private UsuarioSession _session;

        private readonly NavigationService _navigationService;
        public FormMenuPrincipal()
        {
            InitializeComponent();
            _navigationService = new NavigationService(panel_formularios);
            _session = new UsuarioSession();
            linklogoff.Enabled = false;
            linklogoff.Visible = false;
            btn_restaurar.Visible = false;
            btn_FormIncluirAposta.Enabled = false;
            btn_FormListarApostas.Enabled = false;
            btn_ImportarApostas.Visible = false;
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
            var login = new FormLogin(_navigationService, _session);

            login.OnLoginEfetuado += (usuario) =>
            {
                btnFormLoginCadastro.Font = new Font("Segoe UI", 10F);
                btnFormLoginCadastro.Text = $"Bem-vindo, {usuario.Username}";
                btnFormLoginCadastro.Enabled = false;
                btn_FormIncluirAposta.Enabled = true;
                btn_FormListarApostas.Enabled = true;
                if(usuario.Perfil.Equals("Administrador"))
                    btn_ImportarApostas.Visible=true;
                linklogoff.Visible = true;
                linklogoff.Enabled = true;
            };

            _navigationService.NavegarPara(login);
        }
        private void btnFormLoginCadastro_Click(object sender, EventArgs e)
        {
            _navigationService.NavegarPara(new FormLogin(_navigationService, _session));
            AbrirLogin();

        }
        private void btn_incluirAposta_Click(object sender, EventArgs e)
        {
            _navigationService.NavegarPara(new FormGerarApostas(_navigationService, _session));


        }

        private void linklogoff_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _session.Logout();
            btnFormLoginCadastro.Font = new Font("Segoe UI", 15F);
            btnFormLoginCadastro.Text = $" Login\\Cadastro";
            btnFormLoginCadastro.Enabled = true;
            linklogoff.Enabled = false;
            linklogoff.Visible = false;
            btn_FormIncluirAposta.Enabled = false;
            btn_FormListarApostas.Enabled = false;
            btn_ImportarApostas.Visible = false;
            _navigationService.NavegarPara(new FormLogin(_navigationService, _session));

        }

        private void btn_FormListarApostas_Click(object sender, EventArgs e)
        {
            _navigationService.NavegarPara(new FormListarApostas(_navigationService, _session));

        }

        private void btn_ImportarApostas_Click(object sender, EventArgs e)
        {
            _navigationService.NavegarPara(new FormImportarApostas(_navigationService, _session));

        }
    }
}
