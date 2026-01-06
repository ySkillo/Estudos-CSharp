using System;
using System.Collections.Generic;
using System.Text;

namespace ControleDespesas.Models
{
    public class Despesa
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string? Observacao { get; set; } // nullable permitindo valores nulos
    }
}
