using GeradorApostasLotofacil.Domain;

namespace GeradorApostasLotofacil.Session
{
    public class UsuarioSession
    {
        public UsuarioModel? UsuarioLogado { get; private set; }

        public bool EstaAutenticado => UsuarioLogado != null;

        public void Login(UsuarioModel usuario)
        {
            UsuarioLogado = usuario;
        }

        public void Logout()
        {
            UsuarioLogado = null;
        }
    }
}
