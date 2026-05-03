using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.Auth;

public class LoginQueryHandler(IMelodyHubDbContext context, IJwtService jwtService)
    : IRequestHandler<LoginQuery, LoginResult>
{
    public async Task<LoginResult> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.Email);

        var passwordHasher = new PasswordHasher<User>();
        var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

        if (result == PasswordVerificationResult.Failed)
            throw new BadRequestException("Invalid password");

        if (!user.IsVerifiedEmail)
            throw new BadRequestException("Email is not verified");

        return new LoginResult
        {
            Token = jwtService.GenerateToken(user),
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role
        };
    }
}
