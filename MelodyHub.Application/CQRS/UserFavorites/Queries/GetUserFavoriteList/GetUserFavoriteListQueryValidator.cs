using FluentValidation;

namespace MelodyHub.Application.CQRS.UserFavorites.Queries.GetUserFavoriteList;

public class GetUserFavoriteListQueryValidator 
    : AbstractValidator<GetUserFavoriteListQuery>
{
    public GetUserFavoriteListQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEqual(Guid.Empty)
            .WithMessage("User Id must not be empty");
    }
}
