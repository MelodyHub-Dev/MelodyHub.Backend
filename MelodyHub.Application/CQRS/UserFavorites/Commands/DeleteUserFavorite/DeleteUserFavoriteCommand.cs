using MediatR;

namespace MelodyHub.Application.CQRS.UserFavorites.Commands.DeleteUserFavorite;

public class DeleteUserFavoriteCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid InstrumentId { get; set; }
}
