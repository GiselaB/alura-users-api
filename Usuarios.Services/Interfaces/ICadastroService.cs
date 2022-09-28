using FluentResults;
using Usuarios.Services.Dtos;
using Usuarios.Services.Requests;

namespace Usuarios.Services.Interfaces;

public interface ICadastroService
{
    Task<Result> CadastraUsuario(CreateUsuarioDto usuarioDto);
    Result AtivaContaUsuario(AtivaContaRequest request);
}
