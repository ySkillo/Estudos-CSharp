using System;
using System.Collections.Generic;
using System.Text;

namespace PraticaException
{
    public class SaldoInsuficienteException : Exception
    {

        
        public SaldoInsuficienteException(string message)
            : base(message)
        {
        }
        public SaldoInsuficienteException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
