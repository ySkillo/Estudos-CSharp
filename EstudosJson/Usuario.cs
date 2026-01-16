using System;
using System.Collections.Generic;
using System.Text;

namespace EstudosJson
{
    public class Usuario
    {
        //O JSON precisa virar um objeto C#:
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
