namespace GeradorApostasLotofacil.DTO
{
    public class JogoResultadoViewModel
    {
        public int Id { get; set; }
        public JogoViewModel Numeros { get; set; } = new();
    }

    public class JogoViewModel
    {
        public int QuantidadeAcertos { get; set; }
        public List<int> NumerosList { get; set; } = new();

        // Propriedades para compatibilidade com DataGridView
        public int PrimeiroNumero => NumerosList.Count > 0 ? NumerosList[0] : 0;
        public int SegundoNumero => NumerosList.Count > 1 ? NumerosList[1] : 0;
        public int TerceiroNumero => NumerosList.Count > 2 ? NumerosList[2] : 0;
        public int QuartoNumero => NumerosList.Count > 3 ? NumerosList[3] : 0;
        public int QuintoNumero => NumerosList.Count > 4 ? NumerosList[4] : 0;
        public int SextoNumero => NumerosList.Count > 5 ? NumerosList[5] : 0;
        public int SetimoNumero => NumerosList.Count > 6 ? NumerosList[6] : 0;
        public int OitavoNumero => NumerosList.Count > 7 ? NumerosList[7] : 0;
        public int NonoNumero => NumerosList.Count > 8 ? NumerosList[8] : 0;
        public int DecimoNumero => NumerosList.Count > 9 ? NumerosList[9] : 0;
        public int DecimoPrimeiroNumero => NumerosList.Count > 10 ? NumerosList[10] : 0;
        public int DecimoSegundoNumero => NumerosList.Count > 11 ? NumerosList[11] : 0;
        public int DecimoTerceiroNumero => NumerosList.Count > 12 ? NumerosList[12] : 0;
        public int DecimoQuartoNumero => NumerosList.Count > 13 ? NumerosList[13] : 0;
        public int DecimoQuintoNumero => NumerosList.Count > 14 ? NumerosList[14] : 0;
    }
}
