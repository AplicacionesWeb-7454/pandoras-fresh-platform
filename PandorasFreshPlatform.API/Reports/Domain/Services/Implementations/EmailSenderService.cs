
namespace pandoraFr.API.Reports.Domain.Services.Implementations;

public class EmailSenderService : IEmailSenderService
{
    public async Task SendAsync(string to, string subject, string? cc, string body, byte[] attachment, string fileName)
    {
        // Simulación de envío de correo
        await Task.CompletedTask;
    }
}