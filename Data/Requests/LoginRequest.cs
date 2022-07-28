using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Requests
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
