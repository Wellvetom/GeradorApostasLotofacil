namespace GeradorApostasLotofacil.Domain
{
    public class JogoModel
    {
        public int Id { get; set; }
        public List<int> Numeros { get; set; } = new();
        public int ApostaId { get; set; }
        public ApostaModel Aposta { get; set; }
    }
}
