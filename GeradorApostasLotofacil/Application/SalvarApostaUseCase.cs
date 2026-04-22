using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorApostasLotofacil.Application
{
    public class SalvarApostaUseCase
    {
        private readonly ApostaRepository _repo;

        public SalvarApostaUseCase(ApostaRepository repo)
        {
            _repo = repo;
        }

        public void Executar(JogoModel jogo, int concurso)
        {
            //var aposta = new Aposta(jogo, concurso);
            //_repo.Salvar(aposta);
        }
    }
}
