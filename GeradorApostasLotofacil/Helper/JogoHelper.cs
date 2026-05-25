using GeradorApostasLotofacil.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorApostasLotofacil.Helper
{
    public static class JogoHelper
    {
        public static string GerarHashJogo(List<int> numeros)
        {
            return string.Join("-",
                numeros
                    .OrderBy(x => x)
                    .Select(x => x.ToString("D2")));
        }
        public static List<int> ObterNumerosJogo(JogoModel jogo)
        {
            return new List<int>
    {
        jogo.PrimeiroNumero,
        jogo.SegundoNumero,
        jogo.TerceiroNumero,
        jogo.QuartoNumero,
        jogo.QuintoNumero,
        jogo.SextoNumero,
        jogo.SetimoNumero,
        jogo.OitavoNumero,
        jogo.NonoNumero,
        jogo.DecimoNumero,
        jogo.DecimoPrimeiroNumero,
        jogo.DecimoSegundoNumero,
        jogo.DecimoTerceiroNumero,
        jogo.DecimoQuartoNumero,
        jogo.DecimoQuintoNumero
    };
        }
    }
}
