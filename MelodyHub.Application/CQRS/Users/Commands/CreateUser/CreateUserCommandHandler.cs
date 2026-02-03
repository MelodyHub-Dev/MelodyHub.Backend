using MediatR;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.AspNetCore.Identity;

namespace MelodyHub.Application.CQRS.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IMelodyHubDbContext context) : 
    IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, 
        CancellationToken cancellationToken)
    {
        var passwordHasher = new PasswordHasher<User>();

        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            Email = request.Email,
            Role = request.Role,
            IsVerifiedEmail = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };

        newUser.PasswordHash = passwordHasher.HashPassword(newUser, request.Password);

        await context.Users.AddAsync(newUser, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newUser.Id;
    }
}

