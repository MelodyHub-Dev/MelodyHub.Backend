using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Auth;

public class SendVerificationEmailCommandHandler(
    IMelodyHubDbContext context,
    IEmailService emailService)
    : IRequestHandler<SendVerificationEmailCommand>
{
    public async Task Handle(SendVerificationEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FindAsync([request.UserId], cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.UserId);

        if (user.IsVerifiedEmail)
            throw new BadRequestException("Email is already verified");

        // Генерируем 6-значный код
        var token = Random.Shared.Next(100000, 999999).ToString();

        user.EmailVerificationToken = token;
        user.EmailVerificationTokenExpiresAt = DateTime.UtcNow.AddMinutes(15);

        await context.SaveChangesAsync(cancellationToken);

        await emailService.SendEmailVerificationAsync(user.Email, user.Username, token, cancellationToken);
    }
}
