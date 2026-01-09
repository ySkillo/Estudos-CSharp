using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploClassInterface
{
    //Records são tipos imutáveis por padrão, ideais para dados, DTOs, respostas de API, etc.
    /* public record Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        /*{ get; set; } é uma sintaxe de propriedade automática em C#.
          Ela permite que você defina propriedades em uma classe
          sem precisar declarar explicitamente um campo de apoio (backing field).
          O compilador gera automaticamente o campo de apoio para você.*/


        // Construtor da classe Pessoa
      /*  public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }
        // Sobrescreve o método ToString para exibir informações da pessoa
        public override string ToString()
        {
            return $"Nome: {Nome}, Idade: {Idade}";
        }
    }*/



    // Exemplo sem records
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        /*{ get; set; } é uma sintaxe de propriedade automática em C#.
          Ela permite que você defina propriedades em uma classe
          sem precisar declarar explicitamente um campo de apoio (backing field).
          O compilador gera automaticamente o campo de apoio para você.*/

    
        // Construtor da classe Pessoa
        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }
        // Sobrescreve o método ToString para exibir informações da pessoa
        public override string ToString()
        {
            return $"Nome: {Nome}, Idade: {Idade}";
        }
    }
}
