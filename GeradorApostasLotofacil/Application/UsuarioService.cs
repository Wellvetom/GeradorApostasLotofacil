using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Repository;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GeradorApostasLotofacil.Application
{
    public class UsuarioService
    {
        public UsuarioRepositoryInterface _usuarioRepositoryInterface { get; set; }


        public UsuarioService(UsuarioRepositoryInterface usuarioRepositoryInterface)
        {
            _usuarioRepositoryInterface = usuarioRepositoryInterface;
        }

        public async Task CadastrarUsuario(string username, string senha, string email, string perfil)
        {
            var senhaHash = HashPassword(senha);
            UsuarioModel usuario = new UsuarioModel() { Username = username, PasswordHash = senhaHash, Email = email, Perfil = perfil };
           await _usuarioRepositoryInterface.Add(usuario);
        }

        public async Task<UsuarioModel> VerificaLogin(string username, string password)
        {
            var user = await _usuarioRepositoryInterface.GetByUsername(username);

            if (user == null)
                return null;

            var hash = HashPassword(password);

            if (user.PasswordHash != hash)
                return null;
            return user;
        }
        public async Task<UsuarioModel> GetByUsername(string username)
        {
            return await _usuarioRepositoryInterface.GetByUsername(username);
        }
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
