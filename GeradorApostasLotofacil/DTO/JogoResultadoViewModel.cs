using GeradorApostasLotofacil.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorApostasLotofacil.DTO
{
    public class JogoResultadoViewModel
    {
        public int Id { get; set; }

        public JogoViewModel Numeros { get; set; }

    }

    public class JogoViewModel
    {
        public int QuantidadeAcertos { get; set; }

        public int PrimeiroNumero { get; set; }
        public int SegundoNumero { get; set; }
        public int TerceiroNumero { get; set; }
        public int QuartoNumero { get; set; }
        public int QuintoNumero { get; set; }
        public int SextoNumero { get; set; }
        public int SetimoNumero { get; set; }
        public int OitavoNumero { get; set; }
        public int NonoNumero { get; set; }
        public int DecimoNumero { get; set; }
        public int DecimoPrimeiroNumero { get; set; }
        public int DecimoSegundoNumero { get; set; }
        public int DecimoTerceiroNumero { get; set; }
        public int DecimoQuartoNumero { get; set; }
        public int DecimoQuintoNumero { get; set; }
    }
}
