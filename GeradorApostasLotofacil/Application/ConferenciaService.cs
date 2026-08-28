using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.DTO;
using GeradorApostasLotofacil.Helper;
using GeradorApostasLotofacil.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GeradorApostasLotofacil.Application
{
    public class ConferenciaService : IConferenciaService
    {
        private readonly AppDbContext _context;

        public ConferenciaService(AppDbContext context)
        {
            _context = context;
        }

        public List<(string Jogo, int Quantidade)> ObterJogosRepetidos()
        {
            var jogosOficiais = _context.Apostas
                .Where(a => a.UsuarioId == null)
                .SelectMany(a => a.Jogos)
                .AsEnumerable()
                .Select(j => JogoHelper.GerarHashJogoRepetido(j))
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => (
                    Jogo: g.Key,
                    Quantidade: g.Count()
                ))
                .OrderByDescending(x => x.Quantidade)
                .ToList();

            return jogosOficiais;
        }

        public async Task<List<ApostaResultadoViewModel>> ObterApostasComResultado(int usuarioId)
        {
            // apostas do usuário
            var apostasUsuario = await _context.Apostas
                .Where(a => a.UsuarioId == usuarioId && a.DataExclusao == null)
                .Include(a => a.Jogos)
                .ToListAsync();

            // apostas importadas pelo RPA
            var apostasResultado = await _context.Apostas
                .Where(a => a.UsuarioId == null)
                .Include(a => a.Jogos)
                .ToListAsync();

            var resultado = new List<ApostaResultadoViewModel>();

            foreach (var aposta in apostasUsuario)
            {
                // busca resultado oficial da mesma data de apuração
                var resultadoOficial = apostasResultado
                    .FirstOrDefault(r =>
                        r.DataApuracao.HasValue &&
                        aposta.DataApuracao.HasValue &&
                        r.DataApuracao.Value.Date == aposta.DataApuracao.Value.Date);

                var apostaVm = new ApostaResultadoViewModel
                {
                    Id = aposta.Id,
                    NuSorteio = aposta.NuSorteio,
                    DataInclusao = aposta.DataInclusao,
                    DataApuracao = aposta.DataApuracao,
                    Jogos = new List<JogoResultadoViewModel>()
                };

                foreach (var jogoUsuario in aposta.Jogos)
                {
                    int acertos = 0;
                    var jogoDto = new JogoViewModel()
                    {
                        NumerosList = jogoUsuario.Numeros
                    };

                    var numerosUsuario = JogoHelper.ObterNumerosJogo(jogoUsuario);

                    if (resultadoOficial != null)
                    {
                        var jogoResultado = resultadoOficial.Jogos.FirstOrDefault();

                        if (jogoResultado != null)
                        {
                            var numerosResultado = JogoHelper.ObterNumerosJogo(jogoResultado);

                            acertos = numerosUsuario
                                .Intersect(numerosResultado)
                                .Count();
                            jogoDto.QuantidadeAcertos = acertos;
                        }
                    }

                    apostaVm.Jogos.Add(new JogoResultadoViewModel
                    {
                        Id = jogoUsuario.Id,
                        Numeros = jogoDto,
                    });
                }

                resultado.Add(apostaVm);
            }

            return resultado;
        }
    }
}
