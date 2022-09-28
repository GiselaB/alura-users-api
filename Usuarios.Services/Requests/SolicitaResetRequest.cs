using System.ComponentModel.DataAnnotations;

namespace Usuarios.Services.Requests;

public class SolicitaResetRequest
{
    [Required]
    public string Email { get; set; }
}
