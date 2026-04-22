using GeradorApostasLotofacil.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorApostasLotofacil.Repository
{
    public interface ApostaRepositoryInterface
    {
        Task Salvar(ApostaModel aposta);
        Task<List<ApostaModel>> ObterTodas();
        Task<List<ApostaModel>> ObterTodasPorId(int usuarioId);
    }
}
