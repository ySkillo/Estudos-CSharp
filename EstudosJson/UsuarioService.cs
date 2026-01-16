using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace EstudosJson
{
    public class UsuarioService
    {
        private readonly string _caminhoArquivo =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usuarios.json");


        private string LerArquivo()
        {
            if (!File.Exists(_caminhoArquivo))
            {
                File.WriteAllText(_caminhoArquivo, "[]");
            }

            return File.ReadAllText(_caminhoArquivo);
        }

        public void ListarUsuarios()
        {
            string jsonString = LerArquivo();

            // Desserializa o JSON para uma lista de usuários (objeto C#)
            List<Usuario>? usuarios =
                JsonSerializer.Deserialize<List<Usuario>>(jsonString);

            if (usuarios == null || usuarios.Count == 0)
            {
                Console.WriteLine("Nenhum usuário encontrado no arquivo JSON.");
                return;
            }


            foreach (var usuario in usuarios.OrderBy(u => u.Id))
            {
                Console.WriteLine($"ID: {usuario.Id}, Nome: {usuario.Nome}");
            }


        }

        public void SalvarArquivo(List<Usuario> usuario)
        {
            if(usuario == null)
              throw new ArgumentNullException(nameof(usuario), "A lista de usuários não pode ser nula.");


            string jsonString = JsonSerializer.Serialize(
                usuario,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_caminhoArquivo, jsonString);
        }

        public void AdicionarUsuario(Usuario novoUsuario)
        {

            if(novoUsuario == null)
              throw new ArgumentNullException(nameof(novoUsuario), "O usuário não pode ser nulo.");

            string jsonString = LerArquivo();

            List<Usuario> usuarios =
                JsonSerializer.Deserialize<List<Usuario>>(jsonString)
                ?? new List<Usuario>();

            if (usuarios.Any(u => u.Id == novoUsuario.Id))
                throw new InvalidOperationException("Já existe um usuário com esse ID.");

            usuarios.Add(novoUsuario);
            SalvarArquivo(usuarios);

        }
    }
}
