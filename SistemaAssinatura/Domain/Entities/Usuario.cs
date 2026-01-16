using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAssinatura.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }

        public Usuario(string nome, string email)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
        }


        public override string ToString()
        {
            return $"ID: {Id} - Nome: {Nome} - Email: {Email}";
        }
    }
}
