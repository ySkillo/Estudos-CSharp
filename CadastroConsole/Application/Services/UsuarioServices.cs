using CadastroConsole.Application.DTOs;
using CadastroConsole.Application.Interfaces;
using CadastroConsole.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CadastroConsole.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroConsole.Application.Services
{
    internal class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;
       


        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void CriarUsuario(CriarUsuarioRequestDto dto)
        {

            var user = new Usuario(dto.Nome, dto.Email);
            _usuarioRepository.Adicionar(user);
         
        }

        public List<CriarUsuarioResponseDto> ListarUsuarios()
        {
            var usuarios = _usuarioRepository.Listar();

            var response = new List<CriarUsuarioResponseDto>();

            foreach (var usuario in usuarios)
            {
                response.Add(new CriarUsuarioResponseDto
                {
                    Nome = usuario.Nome,
                    Email = usuario.Email
                });
            }

            return response;
        }

    }
}
