using System;
using System.Collections.Generic;

namespace ControleDespesas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* Criar um sistema de controle de gastos, onde o usuário pode:

            Cadastrar despesas

            Listar despesas

            Calcular total gasto

            Filtrar por período

            Lidar com valores nulos */


            var despesas = new List<Models.Despesa>(); // criando um objeto lista de despesas
            var opcao = 0;

            Console.WriteLine("Bem vindo ao sistema de controle de despesas!");


            while (opcao != 5) // enquantos a opcao for diferente de 5 ele executa novamente 
            {

                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Adicionar despesa");
                Console.WriteLine("2 - Listar despesas");
                Console.WriteLine("3 - Calcular total de despesas");
                Console.WriteLine("4 - Filtrar despesa por período");
                Console.WriteLine("5 - Sair");

                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine()!); //O "!" garante que isso não será null

                switch (opcao)
                {
                    case 1:
                        AdicionarDespesa(despesas);
                        break;

                    case 2:
                        ListarDespesas(despesas);
                        break;

                    case 3:
                        CalcularTotalDespesas(despesas);
                        break;

                    case 4:
                        FiltrarDespesasPorPeriodo(despesas);
                        break;

                }
            }


        }

        static void AdicionarDespesa(List<Models.Despesa> despesas)
        {

            Console.Write("Descrição: ");
            var descricao = Console.ReadLine()!;
            Console.Write("Valor: ");
            var valor = Console.ReadLine()!;

            Console.Write("Data (dd/MM/yyyy): ");
            var data = Console.ReadLine()!;

            Console.Write("Observação (opcional): ");
            var observacao = Console.ReadLine();

            var despesa = new Models.Despesa
            {
                Descricao = descricao,
                Valor = decimal.Parse(valor),
                Data = DateTime.Parse(data),
                Observacao = string.IsNullOrWhiteSpace(observacao) ? null : observacao // Operador ternário ? : / condicao ? valorSeTrue : valorSeFalse
            };
            despesas.Add(despesa);

            Console.WriteLine("Despesa adicionada com sucesso!");
        }


        static void ListarDespesas(List<Models.Despesa> despesas)
        {
            if (despesas.Count == 0)
            {
                Console.WriteLine("Nenhuma despesa cadastrada.");
                return;
            }

            foreach (var d in despesas)
            {
                Console.WriteLine(
                    $"📌 {d.Descricao} | R$ {d.Valor:F2} | {d.Data:dd/MM/yyyy} | Obs: {d.Observacao ?? "Sem observação"}"
                );
            }

        }

        static void CalcularTotalDespesas(List<Models.Despesa> despesas)
        {
            var total = despesas.Sum(d => d.Valor);
            Console.WriteLine($"Total gasto: R$ {total:F2}");
        }

        static void FiltrarDespesasPorPeriodo(List<Models.Despesa> despesas)
        {
            Console.Write("Data início (dd/MM/yyyy): ");
            var dataInicio = Console.ReadLine()!;
            Console.Write("Data fim (dd/MM/yyyy): ");
            var dataFim = Console.ReadLine()!;

            var inicio = DateTime.Parse(dataInicio);
            var fim = DateTime.Parse(dataFim);

            var despesasFiltradas = despesas.Where(d => d.Data >= inicio && d.Data <= fim).ToList();
            if (despesasFiltradas.Count == 0)
            {
                Console.WriteLine("Nenhuma despesa encontrada no período informado.");
                return;
            }
            foreach (var d in despesasFiltradas)
            {
                Console.WriteLine(
                    $"📌 {d.Descricao} | R$ {d.Valor:F2} | {d.Data:dd/MM/yyyy} | Obs: {d.Observacao ?? "Sem observação"}"
                );
            }
        }

        }
}