using MediatR;

namespace MelodyHub.Application.CQRS.UserFavorites.Commands.CreateUserFavorite;

public class CreateUserFavoriteCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid InstrumentId { get; set; }
}
