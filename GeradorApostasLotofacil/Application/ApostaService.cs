using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.DTO;
using GeradorApostasLotofacil.Infrastructure;
using GeradorApostasLotofacil.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using GeradorApostasLotofacil.Helper;
namespace GeradorApostasLotofacil.Application
{

    public class ApostaService
    {
        private readonly ApostaRepository _repo;

        public ApostaService(ApostaRepository repo)
        {
            _repo = repo;
        }
        public ApostaModel GerarJogosInteligentes(
            decimal quantidadeJogos)
        {
            try
            {
                using var context = new AppDbContext();

                var random = new Random();

                // TOP 10 FIXOS
                var top10 = _repo.ObterRankingNumeros()
                    .Take(10)
                    .Select(x => x.Numero)
                    .ToList();

                // TODOS os números possíveis
                var todosNumeros = Enumerable.Range(1, 25).ToList();

                // Remove os fixos
                var numerosDisponiveis = todosNumeros
                    .Except(top10)
                    .ToList();

                // Busca jogos já existentes
                var hashesExistentes = context.Jogos
                    .AsEnumerable()
                    .Select(j => JogoHelper.GerarHashJogo(new List<int>
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
                    }))
                    .ToHashSet();

                // Controle dos jogos gerados nessa execução
                var hashesGerados = new HashSet<string>();

                // Cria aposta
                var aposta = new ApostaModel
                {
                    DataInclusao = DateTime.Now,
                    Jogos = new List<JogoModel>()
                };

                while (aposta.Jogos.Count < quantidadeJogos)
                {
                    // Escolhe SOMENTE 5 aleatórios
                    var cincoAleatorios = numerosDisponiveis
                        .OrderBy(x => random.Next())
                        .Take(5)
                        .ToList();

                    // Junta TOP10 + 5 aleatórios
                    var numerosJogo = top10
                        .Concat(cincoAleatorios)
                        .OrderBy(x => x)
                        .ToList();

                    // Gera hash único
                    var hash = JogoHelper.GerarHashJogo(numerosJogo);

                    // Já existe no banco?
                    if (hashesExistentes.Contains(hash))
                        continue;

                    // Já foi gerado nessa aposta?
                    if (hashesGerados.Contains(hash))
                        continue;

                    // Adiciona controle
                    hashesGerados.Add(hash);

                    // Cria jogo
                    var jogo = new JogoModel
                    {
                        PrimeiroNumero = numerosJogo[0],
                        SegundoNumero = numerosJogo[1],
                        TerceiroNumero = numerosJogo[2],
                        QuartoNumero = numerosJogo[3],
                        QuintoNumero = numerosJogo[4],
                        SextoNumero = numerosJogo[5],
                        SetimoNumero = numerosJogo[6],
                        OitavoNumero = numerosJogo[7],
                        NonoNumero = numerosJogo[8],
                        DecimoNumero = numerosJogo[9],
                        DecimoPrimeiroNumero = numerosJogo[10],
                        DecimoSegundoNumero = numerosJogo[11],
                        DecimoTerceiroNumero = numerosJogo[12],
                        DecimoQuartoNumero = numerosJogo[13],
                        DecimoQuintoNumero = numerosJogo[14]
                    };

                    aposta.Jogos.Add(jogo);
                }

                return aposta;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task GravarApostas(ApostaModel aposta)
        {
            await _repo.Salvar(aposta);
        }
        public async Task<List<ApostaModel>> ListarApostas(int usuarioId)
        {
            return await _repo.ObterTodasPorId(usuarioId);
        }
        public async Task<List<ApostaModel>> ObterUltimas10()
        {
            return await _repo.ObterUltimas10();
        }

        public async Task<bool> ImportarApostas()
        {
            try
            {
                var ultimoSorteio = await new LoteriasCaixaRobot.Interface.BuscaSorteioInterface().BuscaSorteio(LoteriasCaixaRobot.Request.BaseRequest.TipoSorteio.Lotofacil);
                var ultimoSorteioGravado = await _repo.ObterUltima();

                if (ultimoSorteio != null)
                {

                    bool finaliza = true;
                    var NuSorteio = ultimoSorteio.Aposta.NuSorteio;
                    var idSor = ultimoSorteioGravado is null ? 1 : ultimoSorteioGravado.NuSorteio;
                    if (idSor == NuSorteio)
                        finaliza = false;


                    while (finaliza)
                    {

                        var buscaSorteio = await new LoteriasCaixaRobot.Interface.BuscaSorteioInterface().BuscaSorteio(LoteriasCaixaRobot.Request.BaseRequest.TipoSorteio.Lotofacil, idSorteio: idSor);

                        ApostaModel gravarAposta = new ApostaModel()
                        {
                            DataApuracao = buscaSorteio.Aposta.DataApuracao,
                            DataInclusao = DateTime.Now,
                            NuSorteio = buscaSorteio.Aposta.NuSorteio,
                            Jogos = new List<JogoModel>()

                        };
                        JogoModel gravarJogo = new JogoModel()
                        {
                            PrimeiroNumero = buscaSorteio.Aposta.JogoVencedor.PrimeiroNumero,
                            SegundoNumero = buscaSorteio.Aposta.JogoVencedor.SegundoNumero,
                            TerceiroNumero = buscaSorteio.Aposta.JogoVencedor.TerceiroNumero,
                            QuartoNumero = buscaSorteio.Aposta.JogoVencedor.QuartoNumero,
                            QuintoNumero = buscaSorteio.Aposta.JogoVencedor.QuintoNumero,
                            SextoNumero = buscaSorteio.Aposta.JogoVencedor.SextoNumero,
                            SetimoNumero = buscaSorteio.Aposta.JogoVencedor.SetimoNumero,
                            OitavoNumero = buscaSorteio.Aposta.JogoVencedor.OitavoNumero,
                            NonoNumero = buscaSorteio.Aposta.JogoVencedor.NonoNumero,
                            DecimoNumero = buscaSorteio.Aposta.JogoVencedor.DecimoNumero,
                            DecimoPrimeiroNumero = buscaSorteio.Aposta.JogoVencedor.DecimoPrimeiroNumero,
                            DecimoSegundoNumero = buscaSorteio.Aposta.JogoVencedor.DecimoSegundoNumero,
                            DecimoTerceiroNumero = buscaSorteio.Aposta.JogoVencedor.DecimoTerceiroNumero,
                            DecimoQuartoNumero = buscaSorteio.Aposta.JogoVencedor.DecimoQuartoNumero,
                            DecimoQuintoNumero = buscaSorteio.Aposta.JogoVencedor.DecimoQuintoNumero
                        };
                        gravarAposta.Jogos.Add(gravarJogo);

                        await _repo.Salvar(gravarAposta);

                        idSor++;
                        if (idSor == NuSorteio)
                            finaliza = false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<List<ApostaResultadoViewModel>> ObterApostasComResultado(int usuarioId)
        {
            using var context = new AppDbContext();

            // apostas do usuário
            var apostasUsuario = await context.Apostas
                .Where(a => a.UsuarioId == usuarioId)
                .Include(a => a.Jogos)
                .ToListAsync();

            // apostas importadas pelo RPA
            var apostasResultado = await context.Apostas
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
                    JogoViewModel jogoDto = new JogoViewModel()
                    {
                        PrimeiroNumero = jogoUsuario.PrimeiroNumero,
                        SegundoNumero=jogoUsuario.SegundoNumero,
                        TerceiroNumero=jogoUsuario.TerceiroNumero,
                        QuartoNumero=jogoUsuario.QuartoNumero,
                        QuintoNumero=jogoUsuario.QuintoNumero,
                        SextoNumero=jogoUsuario.SextoNumero,
                        SetimoNumero=jogoUsuario.SetimoNumero,
                        OitavoNumero=jogoUsuario.OitavoNumero,
                        NonoNumero=jogoUsuario.NonoNumero,
                        DecimoNumero=jogoUsuario.DecimoNumero,
                        DecimoPrimeiroNumero=jogoUsuario.DecimoPrimeiroNumero,
                        DecimoSegundoNumero=jogoUsuario.DecimoSegundoNumero,
                        DecimoTerceiroNumero=jogoUsuario.DecimoTerceiroNumero,
                        DecimoQuartoNumero=jogoUsuario.DecimoQuartoNumero,
                        DecimoQuintoNumero=jogoUsuario.DecimoQuintoNumero
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
