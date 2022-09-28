using Usuarios.Domain.Models;

namespace Usuarios.Services.Interfaces;

public interface ITokenService
{
    Token CreateToken(CustomIdentityUser usuario, string role);
}
