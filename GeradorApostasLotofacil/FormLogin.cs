using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Session;

namespace GeradorApostasLotofacil
{
    public partial class FormLogin : Form
    {
        private readonly NavigationService _navigationService;
        private readonly UsuarioSession _session;
        private readonly IUsuarioService _usuarioService;
        private readonly IServiceProvider _serviceProvider;

        public event Action<UsuarioModel>? OnLoginEfetuado;

        public FormLogin(
            IUsuarioService usuarioService,
            UsuarioSession usuarioSession,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _session = usuarioSession;
            _serviceProvider = serviceProvider;
            _navigationService = new NavigationService(this.Parent as Panel ?? new Panel(), serviceProvider);
        }

        internal void SetNavigationService(NavigationService navigationService)
        {
            // Will be set when navigated via NavigationService
        }

        private NavigationService GetNavigationService()
        {
            // Find parent panel and create navigation service
            if (this.Parent is Panel panel)
                return new NavigationService(panel, _serviceProvider);
            return _navigationService;
        }

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                var login = await _usuarioService.VerificaLogin(txtbox_usuario.Text, txtbox_senha.Text);

                if (login == null)
                {
                    MessageBox.Show("Login incorreto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    _session.Login(login);
                    OnLoginEfetuado?.Invoke(login);

                    var nav = GetNavigationService();
                    var formGerar = _serviceProvider.GetService(typeof(FormGerarApostas)) as Form;
                    if (formGerar != null)
                        nav.NavegarPara(formGerar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar login: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLbl_nao_possui_cadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var nav = GetNavigationService();
            var formCadastro = _serviceProvider.GetService(typeof(FormCadastro)) as Form;
            if (formCadastro != null)
                nav.NavegarPara(formCadastro);
        }
    }
}
