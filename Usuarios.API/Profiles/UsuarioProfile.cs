using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Usuarios.Services.Dtos;
using Usuarios.Domain.Models;

namespace UsuariosAPI.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
        CreateMap<Usuario, CreateUsuarioDto>();
        CreateMap<Usuario, IdentityUser<int>>();
        CreateMap<Usuario, CustomIdentityUser>();
    }
}
