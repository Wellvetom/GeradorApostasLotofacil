using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Repository;
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
        public ApostaModel GerarApostas(decimal qtdApostas, bool isApostasIneditas)
        {
            var aposta = new ApostaModel();
            aposta.Jogos = new List<JogoModel>();
            //if (!isApostasIneditas)
            {
                var jogo = new JogoModel();
                int numeroSorteado;
                var rand = new Random();
                var listaNumeros = new List<int>();
                bool finaliza = true;
                while (finaliza)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        do
                        {
                            numeroSorteado = rand.Next(1, 25);
                        } while (listaNumeros.Contains(numeroSorteado));
                        listaNumeros.Add(numeroSorteado);
                    }
                    listaNumeros.Sort();

                    jogo = new JogoModel()
                    {
                        PrimeiroNumero = listaNumeros[0],
                        SegundoNumero = listaNumeros[1],
                        TerceiroNumero = listaNumeros[2],
                        QuartoNumero = listaNumeros[3],
                        QuintoNumero = listaNumeros[4],
                        SextoNumero = listaNumeros[5],
                        SetimoNumero = listaNumeros[6],
                        OitavoNumero = listaNumeros[7],
                        NonoNumero = listaNumeros[8],
                        DecimoNumero = listaNumeros[9],
                        DecimoPrimeiroNumero = listaNumeros[10],
                        DecimoSegundoNumero = listaNumeros[11],
                        DecimoTerceiroNumero = listaNumeros[12],
                        DecimoQuartoNumero = listaNumeros[13],
                        DecimoQuintoNumero = listaNumeros[14],
                    };
                    listaNumeros.Clear();
                    aposta.Jogos.Add(jogo);

                    if (aposta.Jogos.Count >= qtdApostas)
                        finaliza = false;
                }
            }
            return aposta;
        }
        
        public async Task GravarApostas(ApostaModel aposta)
        {
            await _repo.Salvar(aposta);
        }
        public async Task<List<ApostaModel>> ListarApostas(int usuarioId)
        {
            return await _repo.ObterTodasPorId(usuarioId);
        }
    }
}
