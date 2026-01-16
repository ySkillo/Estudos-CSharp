using SistemaAssinatura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAssinatura.Repositories
{
    public class UsuarioRepository
    {
        private readonly List<Usuario> usuarios;

        public UsuarioRepository()
        {
            usuarios = new List<Usuario>();
        }


        public void Add(Usuario usuario) { 
           usuarios.Add(usuario);
        }

        public List<Usuario> Listar()
        {
            if (usuarios.Count == 0)
                return [];

            return usuarios;
        }
    
        public void Remover(Guid id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario != null)
            {
                usuarios.Remove(usuario);
            }
        }
    
    }
}
