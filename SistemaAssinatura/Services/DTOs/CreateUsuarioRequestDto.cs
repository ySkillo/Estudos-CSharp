using System;

namespace SistemaAssinatura.Application.DTOs.Requests
{
    public class CreateUsuarioRequestDto
    {

        /*DTO de Request(entrada de dados)
        Usado quando o cliente envia dados(POST / PUT).
        Nunca recebe Id, isso é responsabilidade do sistema.*/


        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
