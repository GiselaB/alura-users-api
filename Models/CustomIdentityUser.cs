using Microsoft.AspNetCore.Identity;

namespace UsuariosAPI.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime DataNascimento { get; set; }
    }
}
