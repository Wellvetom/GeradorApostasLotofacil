using GeradorApostasLotofacil.Domain;

namespace GeradorApostasLotofacil.Application
{
    public interface IUsuarioService
    {
        Task CadastrarUsuario(string username, string senha, string email, string perfil);
        Task<UsuarioModel?> VerificaLogin(string username, string password);
        Task<UsuarioModel?> GetByUsername(string username);
    }
}
