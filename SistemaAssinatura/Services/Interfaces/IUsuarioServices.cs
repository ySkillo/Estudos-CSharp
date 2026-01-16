// Requests → dados que ENTRAM no sistema
// Responses → dados que SAEM do sistema
using SistemaAssinatura.Application.DTOs;
using SistemaAssinatura.Application.DTOs.Requests;
using SistemaAssinatura.Application.DTOs.Responses;

namespace SistemaAssinatura.Services.Interfaces
{
    // Interface que define o CONTRATO do serviço de Usuário.
    // Ela diz O QUE o serviço faz, mas não COMO faz.
    //
    // Benefícios de usar interface:
    // - baixo acoplamento
    // - facilidade para testes (mock)
    // - troca de implementação sem quebrar o sistema
    public interface IUsuarioServices
    {
        // Método responsável por CRIAR um usuário no sistema.
        // Recebe um DTO de REQUEST, pois está entrando dado no sistema.
        //
        // A interface não sabe:
        // - como o usuário é salvo
        // - onde é salvo
        // - se é banco, memória, API, etc.
        void CriarUsuario(CreateUsuarioRequestDto request);

        // Método responsável por LISTAR usuários.
        // Retorna um DTO de RESPONSE, pois está saindo dado do sistema.
        //
        // Nunca retorna Entity diretamente,
        // protegendo o domínio e evitando vazamento de dados internos.
        List<UsuarioResponseDto> ListarUsuarios();

        void Remover(Guid id);
    }
}
