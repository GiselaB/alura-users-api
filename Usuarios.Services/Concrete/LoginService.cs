using FluentResults;
using Microsoft.AspNetCore.Identity;
using Usuarios.Services.Requests;
using Usuarios.Domain.Models;
using Usuarios.Services.Interfaces;

namespace Usuarios.Services.Concrete;

public class LoginService : ILoginService
{
    private SignInManager<CustomIdentityUser> _signInManager;
    private ITokenService _tokenService;

    public LoginService(SignInManager<CustomIdentityUser> signInManager, ITokenService tokenService)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public Result LogaUsuario(LoginRequest request)
    {
        var resultadoIdentity = _signInManager
            .PasswordSignInAsync(request.Username, request.Password, false, false);

        if (resultadoIdentity.Result.Succeeded)
        {
            var identityUser = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(usuario => 
                usuario.NormalizedUserName == request.Username.ToUpper());
            Token token = _tokenService
                .CreateToken(identityUser, _signInManager
                    .UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
            return Result.Ok().WithSuccess(token.Value);
        }
        return Result.Fail("Login falhou");
    }

    public Result ResetaSenhaUsuario(EfetuaResetRequest request)
    {
        var identityUser = RecuperaUsuarioPorEmail(request.Email);

        var resultadoIdentity = _signInManager
            .UserManager
            .ResetPasswordAsync(identityUser, request.Token, request.Password)
            .Result;

        if (resultadoIdentity.Succeeded) return Result.Ok()
                .WithSuccess("Senha redefinida com sucesso!");

        return Result.Fail("Houve um erro na operação");
    }

    public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
    {
        var identityUser = RecuperaUsuarioPorEmail(request.Email);

        if (identityUser != null)
        {
            string codigoDeRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
            return Result.Ok().WithSuccess(codigoDeRecuperacao);
        }
        return Result.Fail("Falha ao solicitar redefinição de senha");
    }

    private CustomIdentityUser RecuperaUsuarioPorEmail(string email)
    {
        return _signInManager
                        .UserManager
                        .Users
                        .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
    }
}
