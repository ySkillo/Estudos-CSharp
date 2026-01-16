namespace SistemaAssinatura.Application.DTOs.Responses
{
    // DTO (Data Transfer Object) usado para DEVOLVER dados de um usuário
    // para quem está consumindo a aplicação (API, Angular, HTML/JS, etc).
    //
    // Ele NÃO é uma Entity
    // Ele NÃO contém regras de negócio
    // Ele NÃO acessa banco de dados
    // Serve apenas como CONTRATO de saída.
    public class UsuarioResponseDto
    {
        // Identificador único do usuário.
        // Geralmente vem da Entity (Usuario.Id).
        // É usado pelo frontend para ações como editar, excluir ou detalhar.
        public Guid Id { get; set; }

        // Nome do usuário já validado pelo sistema.
        // Apenas informação para exibição ou consumo externo.
        public string Nome { get; set; }

        // Email do usuário.
        // Deve ser exposto apenas se fizer sentido para o endpoint.
        // Em sistemas reais, nem todo endpoint retorna email.
        public string Email { get; set; }
    }
}
