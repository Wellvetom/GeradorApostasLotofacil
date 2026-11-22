using GeradorApostasLotofacil.Domain;
using System.Runtime.InteropServices;

namespace GeradorApostasLotofacil
{
    /// <summary>
    /// Janela principal da aplicação. Hospeda duas abas (Lotofácil / Mega Sena),
    /// cada uma com sua própria instância de <see cref="FormMenuPrincipal"/> ligada
    /// ao provedor de serviços da respectiva modalidade.
    /// </summary>
    public partial class FormShell : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HL_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private readonly List<FormMenuPrincipal> _menus = new();

        public FormShell()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adiciona uma aba para a modalidade informada, hospedando o menu já inicializado.
        /// </summary>
        public void AdicionarAba(LoteriaConfig config, FormMenuPrincipal menu)
        {
            menu.PrepararComoAba();

            // Sincroniza login/logoff entre as abas (sessão é compartilhada).
            menu.LoginEfetuado += _ => SincronizarLoginDemais(menu);
            menu.LogoffEfetuado += () => SincronizarLogoffDemais(menu);

            var page = new TabPage(config.Nome)
            {
                BackColor = Color.FromArgb(30, 30, 46)
            };
            page.Controls.Add(menu);
            menu.Show();

            tabControl.TabPages.Add(page);
            _menus.Add(menu);
        }

        private void SincronizarLoginDemais(FormMenuPrincipal origem)
        {
            foreach (var m in _menus)
            {
                if (m == origem) continue;
                m.AplicarEstadoLogin();
            }
        }

        private void SincronizarLogoffDemais(FormMenuPrincipal origem)
        {
            foreach (var m in _menus)
            {
                if (m == origem) continue;
                m.ResetarUiLogin();
                m.IrParaLogin();
            }
        }

        private void btn_fechar_Click(object sender, EventArgs e) => Close();

        private void btn_maximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            btn_restaurar.Visible = true;
            btn_maximizar.Visible = false;
        }

        private void btn_restaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
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
    }
}
