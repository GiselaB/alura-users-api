using MimeKit;
using Usuarios.Domain.Models;

namespace Usuarios.Services.Interfaces;

public interface IEmailService
{
    void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code);
    // void Enviar(MimeMessage mensagemDeEmail);
    // MimeMessage CriaCorpoDoEmail(Mensagem mensagem);
}
