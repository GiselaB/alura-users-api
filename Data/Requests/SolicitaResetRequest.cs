using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Requests
{
    public class SolicitaResetRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
