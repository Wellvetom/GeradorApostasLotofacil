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

        public async Task<ApostaModel> ObterUltima()
        {
            return await _context.Apostas.Where(x => x.UsuarioId == null).OrderBy(x => x.Id).LastOrDefaultAsync();
        }
        public async Task<List<ApostaModel>> ObterUltimas10()
        {
            return _context.Apostas.Include(x => x.Jogos).Take(10).ToList();
        }
        public List<(int Numero, int Quantidade)> ObterRankingNumeros()
        {

            var numeros = _context.Jogos
                .AsEnumerable();
            // traz para memória
            var retorno = numeros.SelectMany(j => new List<int>
                {
            j.PrimeiroNumero,
            j.SegundoNumero,
            j.TerceiroNumero,
            j.QuartoNumero,
            j.QuintoNumero,
            j.SextoNumero,
            j.SetimoNumero,
            j.OitavoNumero,
            j.NonoNumero,
            j.DecimoNumero,
            j.DecimoPrimeiroNumero,
            j.DecimoSegundoNumero,
            j.DecimoTerceiroNumero,
            j.DecimoQuartoNumero,
            j.DecimoQuintoNumero
                })
                 .GroupBy(n => n)
                 .Select(g => (
                     Numero: g.Key,
                     Quantidade: g.Count()
                 ))
                 .OrderByDescending(x => x.Quantidade)
                 .ToList();

            return retorno;
        }

        public async Task<List<ApostaModel>> ObterTodas()
        {
            return _context.Apostas.ToList();
        }
        public async Task<List<ApostaModel>> ObterTodasPorId(int usuarioId)
        {
            return await _context.Apostas.Include(x => x.Jogos).Where(x => x.UsuarioId == usuarioId).ToListAsync();
        }
    }
}
