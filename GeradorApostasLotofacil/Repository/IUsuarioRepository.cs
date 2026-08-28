using GeradorApostasLotofacil.Domain;

namespace GeradorApostasLotofacil.Repository
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel?> GetByUsername(string username);
        Task Add(UsuarioModel model);
        Task Update(UsuarioModel model);
    }
}
