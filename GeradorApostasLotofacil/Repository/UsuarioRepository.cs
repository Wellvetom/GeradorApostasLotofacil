using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GeradorApostasLotofacil.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(UsuarioModel model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<UsuarioModel?> GetByUsername(string username)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task Update(UsuarioModel model)
        {
            _context.Usuarios.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
