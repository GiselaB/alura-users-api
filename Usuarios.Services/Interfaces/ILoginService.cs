using FluentResults;
using Usuarios.Domain.Models;
using Usuarios.Services.Requests;

namespace Usuarios.Services.Interfaces;

public interface ILoginService
{
    Result LogaUsuario(LoginRequest request);
    Result ResetaSenhaUsuario(EfetuaResetRequest request);
    Result SolicitaResetSenhaUsuario(SolicitaResetRequest request);
    // CustomIdentityUser RecuperaUsuarioPorEmail(string email);
}
