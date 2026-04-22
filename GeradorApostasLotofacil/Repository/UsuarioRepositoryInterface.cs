using GeradorApostasLotofacil.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorApostasLotofacil.Repository
{
    public interface UsuarioRepositoryInterface
    {
        Task<UsuarioModel> GetByUsername(string username);
        Task Add(UsuarioModel model);
    }
}
