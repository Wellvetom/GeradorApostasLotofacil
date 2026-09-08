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

        public async Task<VerificacaoApostaViewModel> VerificarAposta(int usuarioId, List<int> numeros)
        {
            var numerosOrdenados = numeros.Distinct().OrderBy(n => n).ToList();
            var resultado = new VerificacaoApostaViewModel
            {
                Numeros = numerosOrdenados
            };

            var hashProcurado = JogoHelper.GerarHashJogo(numerosOrdenados);

            // 1) Apostas do próprio usuário que contenham exatamente esses 15 números.
            var apostasUsuario = await _context.Apostas
                .Where(a => a.UsuarioId == usuarioId && a.DataExclusao == null)
                .Include(a => a.Jogos)
                .ToListAsync();

            foreach (var aposta in apostasUsuario)
            {
                bool contemJogo = aposta.Jogos
                    .Any(j => JogoHelper.GerarHashJogo(j.Numeros) == hashProcurado);

                if (contemJogo)
                {
                    resultado.ApostasDoUsuario.Add(new ApostaUsuarioResumo
                    {
                        ApostaId = aposta.Id,
                        DataInclusao = aposta.DataInclusao,
                        DataApuracao = aposta.DataApuracao
                    });
                }
            }

            resultado.ApostasDoUsuario = resultado.ApostasDoUsuario
                .OrderByDescending(a => a.DataInclusao)
                .ToList();

            // 2) Resultados oficiais (importados) e interseção com os números informados.
            var resultadosOficiais = await _context.Apostas
                .Where(a => a.UsuarioId == null)
                .Include(a => a.Jogos)
                .ToListAsync();

            var conjuntoProcurado = numerosOrdenados.ToHashSet();

            foreach (var sorteio in resultadosOficiais)
            {
                var jogoOficial = sorteio.Jogos.FirstOrDefault();
                if (jogoOficial == null) continue;

                var acertados = jogoOficial.Numeros
                    .Where(n => conjuntoProcurado.Contains(n))
                    .OrderBy(n => n)
                    .ToList();

                int acertos = acertados.Count;
                if (acertos < 12) continue;

                var resumo = new SorteioAcertoResumo
                {
                    NuSorteio = sorteio.NuSorteio,
                    DataApuracao = sorteio.DataApuracao,
                    Acertos = acertos,
                    NumerosAcertados = acertados
                };

                switch (acertos)
                {
                    case 15: resultado.Sorteios15.Add(resumo); break;
                    case 14: resultado.Sorteios14.Add(resumo); break;
                    case 13: resultado.Sorteios13.Add(resumo); break;
                    case 12: resultado.Sorteios12.Add(resumo); break;
                }
            }

            // Ordena cada faixa por data de sorteio (mais recente primeiro).
            resultado.Sorteios15 = resultado.Sorteios15.OrderByDescending(s => s.DataApuracao).ToList();
            resultado.Sorteios14 = resultado.Sorteios14.OrderByDescending(s => s.DataApuracao).ToList();
            resultado.Sorteios13 = resultado.Sorteios13.OrderByDescending(s => s.DataApuracao).ToList();
            resultado.Sorteios12 = resultado.Sorteios12.OrderByDescending(s => s.DataApuracao).ToList();

            return resultado;
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
