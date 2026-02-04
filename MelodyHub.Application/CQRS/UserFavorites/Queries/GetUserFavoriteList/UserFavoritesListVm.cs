namespace MelodyHub.Application.CQRS.UserFavorites.Queries.GetUserFavoriteList;

public class UserFavoritesListVm
{
    public IList<Guid> UserFavorites { get; set; } = [];
}
