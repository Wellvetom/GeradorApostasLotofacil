using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorApostasLotofacil.Repository
{
    public class ApostaRepository : ApostaRepositoryInterface
    {
        private readonly AppDbContext _context;

        public ApostaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Salvar(ApostaModel aposta)
        {
            _context.Apostas.Add(aposta);
            _context.SaveChanges();
        }

        public async Task<List<ApostaModel>> ObterTodas()
        {
            return _context.Apostas.ToList();
        }
        public async Task<List<ApostaModel>> ObterTodasPorId(int usuarioId)
        {
            return await _context.Apostas.Include(x=>x.Jogos).Where(x => x.UsuarioId == usuarioId).ToListAsync();
        }
    }
}
