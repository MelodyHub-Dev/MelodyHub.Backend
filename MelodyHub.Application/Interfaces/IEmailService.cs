namespace MelodyHub.Application.Interfaces;

public interface IEmailService
{
    Task SendEmailVerificationAsync(string toEmail, string username, string token, CancellationToken cancellationToken = default);
}
