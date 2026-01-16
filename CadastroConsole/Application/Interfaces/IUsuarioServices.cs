using CadastroConsole.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroConsole.Application.Interfaces
{
    public interface IUsuarioServices
    {
        void CriarUsuario(CriarUsuarioRequestDto dto);
        List<CriarUsuarioResponseDto> ListarUsuarios();
    }
}
