using System;


namespace ExemploClassInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instancia da classe Pessoa
            //Meu objeto pessoa1 do tipo Pessoa
            Pessoa pessoa1 = new Pessoa("João", 30);
            Console.WriteLine(pessoa1.ToString());

            Funcionario funcionario1 = new Funcionario("Maria", 28, 3698.60, "Desenvolvedora WEB", Admissao.PJ);
            Console.WriteLine(funcionario1.ToString());
            funcionario1.Trabalhar();

            Conta conta = new Conta();
            conta.Depositar(500);
            Console.WriteLine($"Saldo atual: {conta.Saldo:F2}");


            //Por que isso é importante?
            //Em classes, == compara referência
            //Em records, compara valores
            /*Pessoa p1 = new Pessoa ("Ana", 25);
            Pessoa p2 = new Pessoa("Ana", 25);
            Console.WriteLine($"Comparação: {p1 == p2}"); //true */

            //Record com with
            //Cria uma cópia alterando só um campo.
            /*var p3 = p1 with { Idade = 16 };
            Console.WriteLine(p3.ToString()); */


            if (funcionario1.EhPJ())
            {
                Console.WriteLine($"{funcionario1.Nome} - é funcionaria PJ");
            }

            
        }
    }
}