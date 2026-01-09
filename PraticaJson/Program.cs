using PraticaJson.Models;
using PraticaJson.Services;

namespace SampleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new UserServices();

          

            Console.WriteLine("Adicionar novo usuário");

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine()!);

            Console.Write("Name: ");
            string name = Console.ReadLine()!;

            var novoUser = new UserModel
            {
                id = id,
                name = name
            };

            service.AdicionarUsuario(novoUser);

            var users = service.LerUsuarios();


            Console.WriteLine($"\nTotal de usuários: {users.Count}");
            Console.WriteLine($"Primeiro usuário: {users[0].name}");
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"ID: {users[i].id} - Name: {users[i].name}");
            }

            Console.WriteLine("\nSelecione o ID do usuario a ser removido");
            int idRemover = int.Parse(Console.ReadLine()!);
            bool removido = service.RemoverUsuario(idRemover);

            Console.WriteLine(removido
                ? $"Usuario com ID {idRemover} removido com sucesso."
                : $"Usuario com ID {idRemover} não encontrado.");

            Console.WriteLine("\nAtualizar nome usuario");
            Console.Write("ID do usuario: ");
            int idAtt = int.Parse(Console.ReadLine()!);

            Console.Write("Name para atualizar: ");
            string nameAtt = Console.ReadLine()!;

            var atualizarUser = new UserModel
            {
                id = idAtt,
                name = nameAtt
            };
            
            service.AtualizarUsuario(atualizarUser);
            users = service.LerUsuarios();

            Console.WriteLine("\nLista de usuários atualizada:");
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"ID: {users[i].id} - Name: {users[i].name}");
            }

        }
    }
}
