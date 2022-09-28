using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Usuarios.Services.Dtos;
using Usuarios.Services.Requests;
using Usuarios.Services.Concrete;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CadastroController : ControllerBase
{
    private CadastroService _cadastroService;

    public CadastroController(CadastroService cadastroService)
    {
        _cadastroService = cadastroService;
    }

    [HttpPost]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto usuarioDto)
    {
        Result resultado = await _cadastroService.CadastraUsuario(usuarioDto);
        if (resultado.IsFailed) return StatusCode(500);
        return Ok(resultado.Successes);
    }

    [HttpGet("/ativa")]
    public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest request)
    {
        Result resultado = _cadastroService.AtivaContaUsuario(request);
        if (resultado.IsFailed) return StatusCode(500);
        return Ok(resultado.Successes);
    }
}
