using MediatR;

namespace MelodyHub.Application.CQRS.UserFavorites.Queries.GetUserFavoriteList;

public class GetUserFavoriteListQuery : IRequest<UserFavoritesListVm>
{
    public Guid UserId { get; set; }
}
