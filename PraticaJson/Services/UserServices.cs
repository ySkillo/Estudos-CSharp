using PraticaJson.Models;
using System.Text.Json;

namespace PraticaJson.Services
{
    internal class UserServices
    {
        private readonly string _caminho = Path.Combine(AppContext.BaseDirectory, "Data", "user.json");
        /* AppContext.BaseDirectory <- Isso aponta para onde o programa está rodando, não para o projeto em si. 
         * Isso é correto e recomendado para apps console. */

        public List<UserModel> LerUsuarios()
        {
            var pasta = Path.GetDirectoryName(_caminho)!; // Pega o diretório onde o arquivo está localizado

            if (!Directory.Exists(pasta)) // Verifica se o diretório existe
            {
                Directory.CreateDirectory(pasta); // Cria o diretório se não existir
            }

            if (!File.Exists(_caminho)) // Verifica se o arquivo existe
            {
                File.WriteAllText(_caminho, "[]"); // Cria o arquivo com um array vazio se não existir
                return new List<UserModel>(); // Retorna uma lista vazia
            }

            string json = File.ReadAllText(_caminho); // Lê o conteúdo do arquivo

            if (string.IsNullOrWhiteSpace(json)) // Verifica se o conteúdo está vazio
                return new List<UserModel>(); // Retorna uma lista vazia

            return JsonSerializer.Deserialize<List<UserModel>>(json)
                   ?? new List<UserModel>(); // Desserializa o JSON para uma lista de UserModel ou retorna uma lista vazia se for nulo
        }


        public void Salvar(List<UserModel> users)
        {
            var json = JsonSerializer.Serialize(
                users,
                new JsonSerializerOptions { WriteIndented = true } // Formata o JSON com indentação para melhor legibilidade
            );

            File.WriteAllText(_caminho, json); // Escreve o JSON no arquivo
        }


        public void AdicionarUsuario(UserModel user)
        {
            var users = LerUsuarios(); // Lê a lista atual de usuários 
            users.Add(user); // Adiciona o novo usuário à lista
            Salvar(users); //   Salva a lista atualizada de usuários
        }

        public bool RemoverUsuario(int id)
        {
            var users = LerUsuarios(); // Lê a lista atual de usuários
            var userToRemove = users.FirstOrDefault(u => u.id == id); // Encontra o usuário com o ID especificado
            if (userToRemove != null)
            {
                users.Remove(userToRemove); // Remove o usuário da lista
                Salvar(users); // Salva a lista atualizada de usuários
                return true; // Retorna true indicando que o usuário foi removido com sucesso
            }
            return false; // Retorna false indicando que o usuário não foi encontrado
        }

        public void AtualizarUsuario(UserModel user)
        {
            var users = LerUsuarios(); // Lê a lista atual de usuários
            var userToUpdate = users.FirstOrDefault(u => u.id == user.id); // Encontra o usuário com o ID especificado
            if (userToUpdate != null)
            {
                userToUpdate.name = user.name; // Atualiza o nome do usuário
                Salvar(users); // Salva a lista atualizada de usuários
            }
        }

       
    }
}
