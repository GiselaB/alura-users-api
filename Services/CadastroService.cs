using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;

        public CadastroService(IMapper mapper, 
            UserManager<IdentityUser<int>> userManager, 
            EmailService emailService, 
            RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }
        public async Task<Result> CadastraUsuario(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
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
}
