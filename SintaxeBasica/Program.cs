using System;


namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            //var não é um tipo, mas uma palavra-chave que permite ao compilador inferir o tipo da variável a partir do valor atribuído a ela.
            var mensagem = "Olá, Mundo!"; // O compilador infere que é do tipo string
            var numero = 42; //O compilador infere que é do tipo int
            var pi = 3.14; // O compilador infere que é do tipo double

           //usar var apenas quando o tipo da variável é óbvio a partir do contexto, para melhorar a legibilidade do código.
            Console.WriteLine(mensagem);
            Console.WriteLine("Número: " + numero);
            Console.WriteLine("Valor de Pi: " + pi);


            //Interpolação de strings
            string nome = "Alice";
            int idade = 30;

            //forma moderna e limpa de montar textos.
            Console.WriteLine($"Nome: {nome}, Idade: {idade} anos");
            Console.Write($"Ano que vem faço {idade + 1}\n");
            //forma antiga
            Console.WriteLine("Nome: " + nome + ", Idade: " + idade + " anos");


            //Criando uma lista para armazenar nomes 
            List<string> nomes = new List<string>();
            nomes.Add("João");
            nomes.Add("Maria");
            nomes.Add("Pedro");

            //A lista também pode ser criada assim:
            var outrosNomes = new List<string>();
            outrosNomes.Add("Ana");
            outrosNomes.Add("Lucas");

            //Adicionando os outrosNomes na lista nomes
            nomes.AddRange(outrosNomes);


            //Percorrendo a lista usando foreach, parecido com FOR ternario de java
            foreach (var n in nomes)
            {
               Console.WriteLine(n);
            }


            //Exemplo de uso DateTime
            DateTime agora = DateTime.Now;
            Console.WriteLine("Data e hora atuais: " + agora.ToString("dd/MM/yyyy")
                + " Hora: " + agora.ToString("HH:mm:ss") + " Apenas o Dia: " + agora.ToString("dd"));

            DateTime hoje = DateTime.Today;
            // Adiciona 10 dias à data atual
            DateTime vencimento = hoje.AddDays(10);
            Console.WriteLine($"Hoje é {hoje:dd/MM/yyyy}. A data de vencimento é {vencimento:dd/MM/yyyy}.");


            //Entenda  NULL e ?
            //? indica que o tipo pode aceitar valores nulos. Nullable types são úteis quando você quer representar a ausência de um valor.
            int? idadeOpcional = null; // A variável pode ser um int ou null

            //?. é o operador de acesso condicional (null-conditional operator).
            //Ele permite acessar membros ou métodos de um objeto somente se ele não for nulo, evitando exceções.
            string? nomeNulo = null;
            Console.WriteLine(nomeNulo?.Length); //Se nome for null, retorna null sem explodir o programa.

            //?? é o operador de coalescência nula (null-coalescing operator).
            string nomeExibido = nomeNulo ?? "Nome não informado"; //Se nome for null, atribui "Nome não informado"
            Console.WriteLine(nomeExibido);

        }
    }
}