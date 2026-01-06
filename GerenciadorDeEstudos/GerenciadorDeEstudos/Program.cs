using System;
using GerenciadorDeEstudos.Models;

namespace GerenciadorDeEstudos
{
    class Program
    {
        static void Main(string[] args)
        {
            var estudo = new List<Estudo>();
            var selecao = 0;

            while (selecao != 5)
            {

                Console.WriteLine("\nSelecione uma opção:");
                Console.WriteLine("1 - Cadastrar uma matéria");
                Console.WriteLine("2 - Marcar como concluída / ");
                Console.WriteLine("3 - Listar matérias");
                Console.WriteLine("4 - Mostrar há quantos dias você começou a estudar algo");
                Console.WriteLine("5 - Sair \n");
                selecao = int.Parse(Console.ReadLine()!);

                switch (selecao)
                {
                    case 1:
                        CadastrarMateria(estudo);
                        break;
                    case 2:
                        MarcarComoConcluida(estudo);
                        break;
                    case 3:
                        ListarMaterias(estudo);
                        break;
                    case 4:
                        MostrarDiasDeEstudo(estudo);
                        break;
                }

            }
        }

        static void CadastrarMateria(List<Estudo> estudos)
        {
            Console.WriteLine("Digite o nome da matéria:");
            var nome = Console.ReadLine()!;
            DateTime dataInicio;

            while (true)
            {
                Console.WriteLine("Digite a data de início (dd/MM/yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out dataInicio))
                    break;

                Console.WriteLine("Data inválida. Tente novamente.");
            }

            bool concluido;
            while (true)
            {
                Console.WriteLine("Concluída? (true/false):");
                if (bool.TryParse(Console.ReadLine(), out concluido))
                    break;

                Console.WriteLine("Valor inválido. Digite true ou false.");
            }

            Console.WriteLine("Observações (opcional):");
            var observacao = Console.ReadLine();

            var estudo = new Estudo
            {
                Nome = nome,
                DataInicio = dataInicio,
                Concluido = concluido,
                Observacao = string.IsNullOrWhiteSpace(observacao) ? null : observacao
            };

            estudos.Add(estudo);

            Console.WriteLine($"Matéria '{nome}' cadastrada com sucesso!");
        }


        static void MarcarComoConcluida(List<Estudo> estudos)
        {
            Console.WriteLine("Digite o nome da matéria que deseja marcar como concluída:");
            var nome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome inválido.");
                return;
            }

            var estudo = estudos.Find(e =>
                e.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (estudo == null)
            {
                Console.WriteLine("Matéria não encontrada.");
                return;
            }

            if (estudo.Concluido)
            {
                Console.WriteLine("Essa matéria já está concluída.");
                return;
            }

            estudo.Concluido = true;
            Console.WriteLine($"Matéria '{estudo.Nome}' marcada como concluída com sucesso!");
        }

        static void ListarMaterias(List<Estudo> estudos)
        {
            if (estudos.Count == 0)
            {
                Console.WriteLine("Nenhuma matéria cadastrada.");
                return;
            }

            Console.WriteLine("\nMatérias cadastradas:\n");

            foreach (var estudo in estudos)
            {
                Console.WriteLine($"Nome: {estudo.Nome}");
                Console.WriteLine($"Data de início: {estudo.DataInicio:dd/MM/yyyy}");
                Console.WriteLine($"Status: {(estudo.Concluido ? "Concluída" : "Em andamento")}");
                Console.WriteLine($"Observações: {estudo.Observacao ?? "Nenhuma"}");
                Console.WriteLine(new string('-', 30));
            }
        }

        static void MostrarDiasDeEstudo(List<Estudo> estudos)
        {
            if (estudos.Count == 0)
            {
                Console.WriteLine("Nenhuma matéria cadastrada.");
                return;
            }
            foreach (var estudo in estudos)
            {
                var diasEstudados = (DateTime.Now - estudo.DataInicio).Days;
                Console.WriteLine($"Você começou a estudar '{estudo.Nome}' há {diasEstudados} dias.");
            }

        }
    }
}