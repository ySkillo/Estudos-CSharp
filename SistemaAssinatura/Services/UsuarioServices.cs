// Importação dos DTOs usados pelo Service.
// Requests → dados que entram no sistema
// Responses → dados que saem do sistema
using SistemaAssinatura.Application.DTOs;
using SistemaAssinatura.Application.DTOs.Requests;
using SistemaAssinatura.Application.DTOs.Responses;

// Importação da Entity de domínio.
// Entities representam o coração das regras de negócio.
using SistemaAssinatura.Domain.Entities;

// Importação do repositório responsável pelo acesso aos dados.
using SistemaAssinatura.Repositories;

// Importação da interface do serviço (contrato).
using SistemaAssinatura.Services.Interfaces;

namespace SistemaAssinatura.Services
{
    // Implementação concreta do serviço de Usuário.
    // Aqui ficam as regras de aplicação e a orquestração
    // entre DTOs, Entities e Repositories.
    //
    // Essa classe IMPLEMENTA o contrato definido em IUsuarioServices.
    public class UsuarioServices : IUsuarioServices
    {
        // Repositório responsável por armazenar e recuperar usuários.
        // É injetado via construtor (Dependency Injection manual).
        private UsuarioRepository _usuarioRepository;

        // Construtor do serviço.
        // Recebe o repositório para evitar acoplamento direto
        // e facilitar testes e manutenção.
        public UsuarioServices(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Método responsável por CRIAR um usuário no sistema.
        // Recebe um DTO de REQUEST, pois os dados estão entrando.
        public void CriarUsuario(CreateUsuarioRequestDto request)
        {
            // Cria a Entity de domínio a partir dos dados do DTO.
            // Aqui ocorre a conversão de Request DTO → Entity.
            var usuario = new Usuario(request.Nome, request.Email);

            // Persiste o usuário através do repositório.
            _usuarioRepository.Add(usuario);
        }

        // Método responsável por LISTAR usuários do sistema.
        // Retorna um DTO de RESPONSE, pois os dados estão saindo.
        public List<UsuarioResponseDto> ListarUsuarios()
        {
            // Busca as Entities no repositório,
            // converte cada Entity em um Response DTO
            // e retorna uma lista pronta para o consumo externo.
            return _usuarioRepository.Listar()
                .Select(u => new UsuarioResponseDto
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email
                })
                .ToList();
        }

        public void Remover(Guid id)
        {
            _usuarioRepository.Remover(id);
        }

    }
}
