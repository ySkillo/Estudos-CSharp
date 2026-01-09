using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploClassInterface
{
    public class Funcionario : Pessoa, ITrabalhavel
    {
        // no java quando vamos hedar a classe usamos a palavra reservada extends
        // no c# usamos a palavra reservada :
        // a mesma coisa para implementar uma interface

        public double Salario { get; set; }
        public string Profissao { get; set; }
        public Admissao Admissao { get; set; }

        // Construtor da classe Funcionario que chama o construtor da classe base Pessoa
        //usamos o base para chamar o construtor da classe base (Pessoa) 
        public Funcionario(string nome, int idade, double salario, string profissao, Admissao admissao) : base(nome, idade)
        {
            this.Salario = salario;
            this.Profissao = profissao;
            this.Admissao = admissao;
        }

        public void Trabalhar()
        {
            Console.WriteLine($"{Nome} está trabalhando como {Profissao}.");
        }

        // Método para verificar se o funcionário é PJ Encapsulamento da lógica de verificação
        public bool EhPJ()
        {
             return Admissao == Admissao.PJ;

        }

        // Sobrescreve o método ToString para exibir informações do funcionário
        //usamos o override para sobrescrever um método da classe base
        // e utilizamos o base para chamar o método da classe base (Pessoa) poderia ser por exemplo base.MediaSalarial()

        public override string ToString()
        {
            return $"Funcionario - {base.ToString()}, Salário: {Salario:F2}, Profissão: {Profissao}, Admissao: {Admissao}";
        }

    }
}
