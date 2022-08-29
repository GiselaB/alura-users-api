using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Services;
using UsuariosAPI.Data.Requests;
using FluentResults;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request)
        {
            Result resultado = _loginService.LogaUsuario(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);
        }

        [HttpPost("/solicita-reset")]
        public IActionResult SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            Result resultado = _loginService.SolicitaResetSenhaUsuario(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);
        }

        [HttpPost("/efetua-reset")]
        public IActionResult ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            Result resultado = _loginService.ResetaSenhaUsuario(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);
        }
    }
}
