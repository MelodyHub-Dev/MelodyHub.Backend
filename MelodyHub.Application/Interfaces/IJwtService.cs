using MelodyHub.Domain;

namespace MelodyHub.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}
