using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorApostasLotofacil.Domain
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Perfil { get; set; } // Admin, User    }
        public List<ApostaModel>? Apostas { get; set; }

    }
}
