using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Session;

namespace GeradorApostasLotofacil
{
    public partial class FormCadastro : Form
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IServiceProvider _serviceProvider;

        public FormCadastro(
            IUsuarioService usuarioService,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _serviceProvider = serviceProvider;
        }

        private async void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = txtbox_usuario.Text;
                var senha = maskedtxtbox_senha.Text;
                var email = txtbox_Email.Text;
                var perfil = cmbBox_Perfil.SelectedItem?.ToString() ?? "User";

                await _usuarioService.CadastrarUsuario(usuario, senha, email, perfil);
                MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Navigate to login
                if (this.Parent is Panel panel)
                {
                    var nav = new NavigationService(panel, _serviceProvider);
                    var formLogin = _serviceProvider.GetService(typeof(FormLogin)) as Form;
                    if (formLogin != null)
                        nav.NavegarPara(formLogin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
