namespace GeradorApostasLotofacil.Domain
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Perfil { get; set; } = string.Empty;
        public List<ApostaModel>? Apostas { get; set; }
    }
}
