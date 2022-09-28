using Microsoft.AspNetCore.Identity;

namespace Usuarios.Domain.Models;

public class CustomIdentityUser : IdentityUser<int>
{
    public DateTime DataNascimento { get; set; }
}
