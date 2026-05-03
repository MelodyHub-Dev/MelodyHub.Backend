using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.Auth;

public class VerifyEmailCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<VerifyEmailCommand>
{
    public async Task Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.EmailVerificationToken == request.Token, cancellationToken)
            ?? throw new NotFoundException("User", request.Token);

        if (user.EmailVerificationTokenExpiresAt < DateTime.UtcNow)
            throw new BadRequestException("Verification token has expired");

        user.IsVerifiedEmail = true;
        user.EmailVerificationToken = null;
        user.EmailVerificationTokenExpiresAt = null;
        user.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);
    }
}
