using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LinqLambda

{
    class Program
    {
        static void Main(string[] args)
        {
            //sem LINQ:
            var numeros = new List<int> { 5, 10, 15, 20, 25, 30 };
            var maiores = new List<int>();

            foreach (var n in numeros)
            {
                if (n > 10)
                    maiores.Add(n);
            }

            //com LINQ:
            maiores = numeros.Where(n => n > 10).ToList();
            Console.WriteLine(string.Join(", ", maiores)) ;

            //Lambda seria (=>):
            /*
             Exemplo:
                x => x * x;
                p => p.Nome.StartsWith("A"); nomes que começam com A
                d => d.Idade >= 18; maiores de idade
             */

            // para filtrar todos os numeros pares:
            var pares = numeros.Where(n => n % 2 == 0).ToList();
            Console.WriteLine(string.Join(", ", pares));

            //para filtrar dados usamos (Where)
            /*
              exemplo:
                var adultos = pessoas.Where(p => pessoa.Idade >= 18).ToList();
                Filtrer uma lista de pessoas para obter apenas os adultos (idade >= 18).
                "p" é o parâmetro que representa cada elemento da coleção "pessoas".
                pessoa.Idade é a propriedade que estamos avaliando.
             */


            //para projetar dados usamos (Select)
            /*
               por exemplo:
                var nomes = pessoas.Select(p => p.Nome).ToList();
                Extrair apenas os nomes de uma lista de objetos "pessoas".
                "p" é o parâmetro que representa cada elemento da coleção "pessoas".
                pessoa.Nome é a propriedade que estamos selecionando.
                ToList() converte o resultado em uma lista.
             */

            //para agregar dados usamos (Sum, Average, Count, Max, Min)
            /*
             por exemplo: 
                var totalIdade = pessoas.Sum(p => p.Idade);
                Calcular a soma das idades em uma lista de objetos "pessoas".
                "p" é o parâmetro que representa cada elemento da coleção "pessoas".
                pessoa.Idade é a propriedade que estamos somando.
             */

            //para ordenar dados usamos (OrderBy, OrderByDescending)
            /*
             por exemplo:
                var pessoasOrdenadas = pessoas.OrderBy(p => p.Nome).ToList();
                Ordenar uma lista de objetos "pessoas" pelo nome em ordem crescente.
                "p" é o parâmetro que representa cada elemento da coleção "pessoas".
                pessoa.Nome é a propriedade pela qual estamos ordenando.
             */

            //para agrupar dados usamos (GroupBy)
            /*
             por exemplo:
                var pessoasPorIdade = pessoas.GroupBy(p => p.Idade);
                Agrupar uma lista de objetos "pessoas" pela idade.
                "p" é o parâmetro que representa cada elemento da coleção "pessoas".
                pessoa.Idade é a propriedade pela qual estamos agrupando.
             */

            //para combinar dados usamos (Join)
            /*
             por exemplo:
                var pessoasComCidades = pessoas.Join(cidades,
                                                     p => p.CidadeId,
                                                     c => c.Id,
                                                     (p, c) => new { PessoaNome = p.Nome, CidadeNome = c.Nome });
                Combinar duas listas, "pessoas" e "cidades", com base em uma chave comum (CidadeId).
                "p" representa cada elemento da coleção "pessoas" e "c" representa cada elemento da coleção "cidades".
                O resultado é uma nova coleção que contém o nome da pessoa e o nome da cidade.
             */

            //para verificar condições usamos (Any, All)
            /*
             por exemplo:
                var existeAdulto = pessoas.Any(p => p.Idade >= 18);
                Verificar se existe pelo menos uma pessoa adulta (idade >= 18) na lista "pessoas".
                "p" é o parâmetro que representa cada elemento da coleção "pessoas".
             */

            var idades = new List<int> { 15, 16, 24, 10, 13, 27, 30 };
            var nomes = new List<string> { "Ana", "Bruno", "Carlos", "Amanda", "Beatriz", "Maria", "Matheus" };

            // Verifica se existe pelo menos uma idade maior de 18
            // E se existe pelo menos um nome que começa com C ou M
            // Usando Any para verificar as condições
            var existeMaiorDe18 = idades.Any(i => i > 18) &&
                                  nomes.Any(n => n.StartsWith("C") || n.StartsWith("M"));

            // Lista de nomes com idades maiores de 18 anos
            // Usando Zip para combinar nomes e idades
            // Depois filtrando e projetando os resultados
            // Usando Where para filtrar idades maiores de 18
            // Usando Select para formatar a saída
            // Convertendo para lista com ToList
            var maioresDe18 = nomes
                 .Zip(idades, (nome, idade) => new { nome, idade })
                 .Where(x => x.idade > 18)
                 .Select(x => $"{x.nome} ({x.idade} anos)")
                 .ToList();

            Console.WriteLine($"Existe maior de 18 e nome começando com C ou M? {existeMaiorDe18}");
            Console.WriteLine("Nomes maiores de idade: " + string.Join(", ", maioresDe18));


        }
    }
}   