using System;

/*
 para trabalhar usando JSON em C#, você pode usar a biblioteca Newtonsoft.Json (Json.NET)
ou a biblioteca System.Text.Json que é integrada ao .NET Core 3.0 e versões posteriores.
 */
using System.Text.Json;



namespace EstudosJson
{
    class Program
    {
        static void Main(string[] args)
        {
            UsuarioService usuarioService = new UsuarioService();

            Usuario novoUsuario = new Usuario { 
                Id = 2,
                Nome = "Gustavo"
            };

            usuarioService.AdicionarUsuario(novoUsuario);

            usuarioService.ListarUsuarios();

            

           


        }
    }
}