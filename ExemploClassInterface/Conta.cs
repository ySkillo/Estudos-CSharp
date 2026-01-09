using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploClassInterface
{
    public class Conta
    {
        private double _saldo;

        //Propriedade pública para acessar o saldo
        //com validação no set
        //Saldo é uma propriedade pública que encapsula o campo privado _saldo
        //e permite controlar o acesso a ele com validação no set da propriedade.
        public double Saldo
        {
            get { return _saldo; }
            set 
            { _saldo = value; }
           
        }

        public void Depositar(double valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor de depósito deve ser positivo.");
            Saldo += valor;
        }
    }
}
