using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeEstudos.Models
{
    public class Estudo
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public bool Concluido { get; set; }
        public string? Observacao { get; set; }
    }
}
