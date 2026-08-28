using GeradorApostasLotofacil.Domain;

namespace GeradorApostasLotofacil.Helper
{
    public static class JogoHelper
    {
        public static string GerarHashJogoRepetido(JogoModel jogo)
        {
            return GerarHashJogo(jogo.Numeros);
        }

        public static string GerarHashJogo(List<int> numeros)
        {
            return string.Join("-",
                numeros
                    .OrderBy(x => x)
                    .Select(x => x.ToString("D2")));
        }

        public static List<int> ObterNumerosJogo(JogoModel jogo)
        {
            return jogo.Numeros;
        }
    }
}
