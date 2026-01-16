using CadastroConsole.Application.DTOs;
using CadastroConsole.Application.Interfaces;
using CadastroConsole.Application.Services;
using CadastroConsole.Infrastructure.Repositories;
using System;

namespace CadastroConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();
            context.Database.EnsureCreated();

            var usuarioRepository = new UsuarioRepository(context);
            var us = new UsuarioServices(usuarioRepository);

            string continuar = "";

            do
            {
                Console.WriteLine("Nome: ");
                var Nome = Console.ReadLine();
                Console.WriteLine("Email: ");
                var Email = Console.ReadLine();

                var dto = new CriarUsuarioRequestDto
                {
                    Nome = Nome,
                    Email = Email
                };

                us.CriarUsuario(dto);

                Console.WriteLine("Deseja adicionar mais usuario? s/n");
                continuar = Console.ReadLine();

            } while (continuar == "s");



            var usuarios = us.ListarUsuarios();
            foreach (var user in usuarios)
            {
                Console.WriteLine($"Nome: {user.Nome} - Email: {user.Email}");
            }

            Console.WriteLine("\n programa finalizado");

        }
    }
}
