using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorApostasLotofacil.Repository
{
    public class UsuarioRepository : UsuarioRepositoryInterface
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(UsuarioModel model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public  Task<UsuarioModel> GetByUsername(string username)
        {
            return _context.Usuarios.FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}
