using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using Usuarios.Services.Dtos;
using Usuarios.Services.Requests;
using Usuarios.Domain.Models;
using Usuarios.Services.Interfaces;

namespace Usuarios.Services.Concrete;

public class CadastroService : ICadastroService
{
    private IMapper _mapper;
    private UserManager<CustomIdentityUser> _userManager;
    private EmailService _emailService;

    public CadastroService(IMapper mapper, 
        UserManager<CustomIdentityUser> userManager, 
        EmailService emailService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _emailService = emailService;
    }
    public async Task<Result> CadastraUsuario(CreateUsuarioDto usuarioDto)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDto);
        var usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);
        var result = await _userManager.CreateAsync(usuarioIdentity, usuarioDto.Password);

        // essa parte não funciona
        await _userManager.AddToRoleAsync(usuarioIdentity, "regular");

        if (result.Succeeded)
        {
            // var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
           //  var encodedCode = HttpUtility.UrlEncode(code);
            // _emailService.EnviarEmail(new[] {usuarioIdentity.Email}, "Link de ativação", usuarioIdentity.Id, encodedCode);
            return Result.Ok().WithSuccess(/*code*/ "Cadastro realizado com sucesso!");
        }

        return Result.Fail("Falha ao cadastrar usuário");
    }

    public Result AtivaContaUsuario(AtivaContaRequest request)
    {
        var identityUser = _userManager
            .Users
            .FirstOrDefault(u => u.Id == request.UsuarioId);
        var identityResult = _userManager
            .ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;
        if (identityResult.Succeeded) return Result.Ok();
        return Result.Fail("Falha ao ativar conta de usuário");
    }
}
