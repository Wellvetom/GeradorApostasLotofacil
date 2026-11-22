namespace GeradorApostasLotofacil.Domain
{
    public class ApostaModel
    {
        public int Id { get; private set; }
        public int NuSorteio { get; set; }

        /// <summary>
        /// Modalidade de loteria à qual esta aposta/sorteio pertence.
        /// Segrega os dados de Lotofácil e Mega Sena na mesma tabela.
        /// </summary>
        public Modalidade Modalidade { get; set; } = Modalidade.Lotofacil;

        public List<JogoModel> Jogos { get; set; } = new();
        public DateTime DataInclusao { get; set; }
        public DateTime? DataApuracao { get; set; }
        public DateTime? DataExclusao { get; set; }

        public int? UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }
    }
}
