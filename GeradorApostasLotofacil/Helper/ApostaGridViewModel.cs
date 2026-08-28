namespace GeradorApostasLotofacil.Helper
{
    public class ApostaGridViewModel
    {
        public int Id { get; set; }
        public int ApostaId { get; set; }
        public string DataInclusao { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public int Acertos { get; set; }
        public List<int> Numeros { get; set; } = new();

        // Propriedades para exibição no DataGridView (mapeiam da lista)
        public int PrimeiroNumero => Numeros.Count > 0 ? Numeros[0] : 0;
        public int SegundoNumero => Numeros.Count > 1 ? Numeros[1] : 0;
        public int TerceiroNumero => Numeros.Count > 2 ? Numeros[2] : 0;
        public int QuartoNumero => Numeros.Count > 3 ? Numeros[3] : 0;
        public int QuintoNumero => Numeros.Count > 4 ? Numeros[4] : 0;
        public int SextoNumero => Numeros.Count > 5 ? Numeros[5] : 0;
        public int SetimoNumero => Numeros.Count > 6 ? Numeros[6] : 0;
        public int OitavoNumero => Numeros.Count > 7 ? Numeros[7] : 0;
        public int NonoNumero => Numeros.Count > 8 ? Numeros[8] : 0;
        public int DecimoNumero => Numeros.Count > 9 ? Numeros[9] : 0;
        public int DecimoPrimeiroNumero => Numeros.Count > 10 ? Numeros[10] : 0;
        public int DecimoSegundoNumero => Numeros.Count > 11 ? Numeros[11] : 0;
        public int DecimoTerceiroNumero => Numeros.Count > 12 ? Numeros[12] : 0;
        public int DecimoQuartoNumero => Numeros.Count > 13 ? Numeros[13] : 0;
        public int DecimoQuintoNumero => Numeros.Count > 14 ? Numeros[14] : 0;
    }
}
