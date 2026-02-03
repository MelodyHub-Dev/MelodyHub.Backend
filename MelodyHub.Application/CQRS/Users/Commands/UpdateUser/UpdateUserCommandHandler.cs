using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHasher = new PasswordHasher<User>();

        var user = await context.Users
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.Id);

        var verificationResult = passwordHasher.VerifyHashedPassword(
            user,
            user.PasswordHash, 
            request.Password   
        );

        if (verificationResult != PasswordVerificationResult.Success)
        {
            throw new BadRequestException("Passwords do not match");
        }

        if (user.Email != request.Email)
        {
            var emailExists = await context.Users
                .AnyAsync(u => u.Email == request.Email && u.Id != request.Id, cancellationToken);

            if (emailExists)
            {
                throw new BadRequestException("The email is already in use by another user");
            }
        }

        var hashedNewPassword = passwordHasher.HashPassword(user, request.Password);

        user.Email = request.Email;
        user.Username = request.Username;
        user.PasswordHash = hashedNewPassword;
        user.Role = request.Role;
        user.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);
    }
}