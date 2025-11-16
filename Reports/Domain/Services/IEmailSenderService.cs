namespace pandoraFr.API.Reports.Domain.Services;

public interface IEmailSenderService
{
    Task SendAsync(string to, string subject, string? body, string attachmentName, byte[] attachmentBytes, string attachmentMime);
}