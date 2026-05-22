using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Infrastructure;
using GeradorApostasLotofacil.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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

                // TOP 10 números mais frequentes
                var top10 = _repo.ObterRankingNumeros()
                    .Take(10)
                    .Select(x => x.Numero)
                    .ToList();

                var random = new Random();

                // controle de hashes existentes no banco
                var jogosExistentes = context.Jogos
                    .AsEnumerable()
                    .Select(j => GerarHashJogo(new List<int>
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

                // controle dos jogos gerados nesta execução
                var jogosGerados = new HashSet<string>();

                // cria aposta
                var aposta = new ApostaModel
                {
                    DataInclusao = DateTime.Now,
                    Jogos = new List<JogoModel>()
                };

                while (aposta.Jogos.Count < quantidadeJogos)
                {
                    // escolhe 5 aleatórios fora do TOP10
                    var restantes = Enumerable.Range(1, 25)
                        .Except(top10)
                        .OrderBy(x => random.Next())
                        .Take(5)
                        .ToList();

                    // jogo final
                    var numerosJogo = top10
                        .Concat(restantes)
                        .OrderBy(x => x)
                        .ToList();

                    // gera hash
                    var hashJogo = GerarHashJogo(numerosJogo);

                    // valida duplicidade
                    if (jogosExistentes.Contains(hashJogo))
                        continue;

                    if (jogosGerados.Contains(hashJogo))
                        continue;

                    // adiciona controle
                    jogosGerados.Add(hashJogo);

                    // cria jogo
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

        private string GerarHashJogo(List<int> numeros)
        {
            return string.Join("-",
                numeros
                    .OrderBy(x => x)
                    .Select(x => x.ToString("D2")));
        }
    }
}
