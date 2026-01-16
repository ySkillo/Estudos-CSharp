using CadastroConsole.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroConsole.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        List<Usuario> Listar();
    }

    
}
