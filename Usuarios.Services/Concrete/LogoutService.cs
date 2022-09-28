using FluentResults;
using Microsoft.AspNetCore.Identity;
using Usuarios.Domain.Models;
using Usuarios.Services.Interfaces;

namespace Usuarios.Services.Concrete;

public class LogoutService : ILogoutService
{
    private SignInManager<CustomIdentityUser> _signInManager;

    public LogoutService(SignInManager<CustomIdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public Result DeslogaUsuario()
    {
        var resultadoIdentity = _signInManager.SignOutAsync();
        if (resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();
        return Result.Fail("Logout falhou");
    }
}
