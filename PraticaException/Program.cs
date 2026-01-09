using System;
using System.Drawing;

namespace PraticaException;

class Program
{
    static void Main(string[] args)
    {
        //Estrutura básica de tratamento de exceções
        /*
            try → código que pode dar erro
            catch → trata o erro se ele acontecer
            finally → sempre executa (erro ou não)
         */
        try
        {
            int x = int.Parse("abc");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Bloco finally executado. Sempre executa");
        }

        //Tipos comuns de Exceptions
        /*
            FormatException        // erro de conversão
            DivideByZeroException  // divisão por zero
            NullReferenceException // objeto nulo
            FileNotFoundException  // arquivo não encontrado
            InvalidOperationException // operação inválida
        */

        // Lançando sua própria exception(throw)
        try
        {
            int idade = -5;
            if (idade < 0)
            {
                throw new ArgumentOutOfRangeException("Idade não pode ser negativa.");
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Erro ao definir idade: {ex.Message}");
        }

        var saldo = 200;
        var saque = 150;

        if (saldo < 0)
        {
            Console.WriteLine("Saldo inicial inválido: não pode ser negativo.");
            saldo = 0;
        }

        try
        {
            if (saque > saldo)
                throw new SaldoInsuficienteException("Saldo insuficiente");
            var resultado = saldo - saque;
            Console.WriteLine(resultado);
        }
        catch (SaldoInsuficienteException ex)
        {
            
            Console.WriteLine($"Erro ao realizar saque: {ex.Message}");
        }


    }
}
