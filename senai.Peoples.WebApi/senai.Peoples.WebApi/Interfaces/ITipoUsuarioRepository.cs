using senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> Listar();

        void Cadastrar(TipoUsuarioDomain novoTipo);

        void Atualizar(int id, TipoUsuarioDomain TipoUsuarioAtualizado);

        void Deletar(int id);

        TipoUsuarioDomain BuscarPorId(int id);
    }
}
