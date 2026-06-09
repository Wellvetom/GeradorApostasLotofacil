using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorApostasLotofacil.Domain
{
    public class ApostaModel
    {
        public int Id { get; private set; }
        public int NuSorteio { get; set; }
        public List<JogoModel> Jogos { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataApuracao { get; set; }
        public DateTime? DataExclusao { get; set; }

        public int? UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }
    }
}
