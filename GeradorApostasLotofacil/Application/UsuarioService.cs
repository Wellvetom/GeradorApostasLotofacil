using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Repository;
using System.Security.Cryptography;
using System.Text;

namespace GeradorApostasLotofacil.Application
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task CadastrarUsuario(string username, string senha, string email, string perfil)
        {
            var senhaHash = HashPassword(senha);
            UsuarioModel usuario = new UsuarioModel()
            {
                Username = username,
                PasswordHash = senhaHash,
                Email = email,
                Perfil = perfil
            };
            await _usuarioRepository.Add(usuario);
        }

        public async Task<UsuarioModel?> VerificaLogin(string username, string password)
        {
            var user = await _usuarioRepository.GetByUsername(username);

            if (user == null)
                return null;

            bool senhaValida;

            if (IsBCryptHash(user.PasswordHash))
            {
                // Hash já é BCrypt — verificação normal
                senhaValida = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            }
            else
            {
                // Hash legado (SHA256) — verifica e migra para BCrypt
                senhaValida = VerifyLegacySha256(password, user.PasswordHash);

                if (senhaValida)
                {
                    user.PasswordHash = HashPassword(password);
                    await _usuarioRepository.Update(user);
                }
            }

            return senhaValida ? user : null;
        }

        public async Task<UsuarioModel?> GetByUsername(string username)
        {
            return await _usuarioRepository.GetByUsername(username);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private static bool IsBCryptHash(string hash)
        {
            return hash.StartsWith("$2a$") || hash.StartsWith("$2b$") || hash.StartsWith("$2y$");
        }

        private static bool VerifyLegacySha256(string password, string storedHash)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var computedHash = Convert.ToBase64String(bytes);
            return computedHash == storedHash;
        }
    }
}
