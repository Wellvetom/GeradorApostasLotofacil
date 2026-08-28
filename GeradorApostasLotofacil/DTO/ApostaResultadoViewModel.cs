namespace GeradorApostasLotofacil.DTO
{
    public class ApostaResultadoViewModel
    {
        public int Id { get; set; }
        public int NuSorteio { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataApuracao { get; set; }
        public List<JogoResultadoViewModel> Jogos { get; set; } = new();
    }
}
