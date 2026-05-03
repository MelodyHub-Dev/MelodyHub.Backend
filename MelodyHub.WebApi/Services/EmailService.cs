using MelodyHub.Application.Interfaces;
using System.Net;
using System.Net.Mail;

namespace MelodyHub.WebApi.Services;

public class EmailService(IConfiguration configuration) : IEmailService
{
    public async Task SendEmailVerificationAsync(
        string toEmail,
        string username,
        string token,
        CancellationToken cancellationToken = default)
    {
        var smtp = configuration.GetSection("SmtpSettings");

        var host = smtp["Host"] ?? throw new InvalidOperationException("SMTP Host not configured");
        var port = int.Parse(smtp["Port"] ?? "587");
        var senderEmail = smtp["SenderEmail"] ?? throw new InvalidOperationException("SMTP SenderEmail not configured");
        var senderPassword = smtp["SenderPassword"] ?? throw new InvalidOperationException("SMTP SenderPassword not configured");
        var senderName = smtp["SenderName"] ?? "MelodyHub";

        var body = $"""
            <div style="font-family: Arial, sans-serif; max-width: 480px; margin: 0 auto; background: #0f0f0f; color: #fff; border-radius: 12px; padding: 32px;">
              <h2 style="color: #ff6b00; margin-bottom: 8px;">Подтверждение email</h2>
              <p style="color: #aaa;">Привет, <strong style="color:#fff">{username}</strong>!</p>
              <p style="color: #aaa;">Введи этот код для подтверждения email-адреса:</p>
              <div style="background: #1a1a1a; border: 1px solid #333; border-radius: 10px; padding: 24px; text-align: center; margin: 24px 0;">
                <span style="font-size: 36px; font-weight: 700; letter-spacing: 12px; color: #ff6b00;">{token}</span>
              </div>
              <p style="color: #666; font-size: 13px;">Код действителен 15 минут. Если ты не регистрировался — просто проигнорируй это письмо.</p>
            </div>
            """;

        using var client = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(senderEmail, senderPassword),
            EnableSsl = true
        };

        var message = new MailMessage
        {
            From = new MailAddress(senderEmail, senderName),
            Subject = "Подтверждение email — MelodyHub",
            Body = body,
            IsBodyHtml = true
        };
        message.To.Add(toEmail);

        await client.SendMailAsync(message, cancellationToken);
    }
}
