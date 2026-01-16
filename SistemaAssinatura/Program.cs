using SistemaAssinatura.Application.DTOs.Requests;
using SistemaAssinatura.Repositories;
using SistemaAssinatura.Services;
using System;
using System.Linq; // 👈 necessário para FirstOrDefault

namespace SistemaAssinatura
{
    class Program
    {
        public static void Main(string[] args)
        {
            var repository = new UsuarioRepository();
            var userService = new UsuarioServices(repository);

            // Criação dos usuários
            userService.CriarUsuario(new CreateUsuarioRequestDto
            {
                Nome = "Matheus",
                Email = "matheus@gmail.com"
            });

            userService.CriarUsuario(new CreateUsuarioRequestDto
            {
                Nome = "Ivanilde",
                Email = "ivanilde@gmail.com"
            });

            // Listagem dos usuários
            var usuarios = userService.ListarUsuarios();

            Console.WriteLine("Usuários antes da remoção:");
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"{usuario.Id} - {usuario.Nome} - {usuario.Email}");
            }

            // Busca o usuário que será removido
            var usuarioRemover = usuarios.FirstOrDefault(u => u.Nome == "Ivanilde");

            // Boa prática: sempre validar null
            if (usuarioRemover != null)
            {
                userService.Remover(usuarioRemover.Id);
            }

            // Listagem após remoção
            Console.WriteLine("\nUsuários após a remoção:");
            var usuariosAtualizados = userService.ListarUsuarios();

            foreach (var usuario in usuariosAtualizados)
            {
                Console.WriteLine($"{usuario.Id} - {usuario.Nome} - {usuario.Email}");
            }
        }
    }
}
