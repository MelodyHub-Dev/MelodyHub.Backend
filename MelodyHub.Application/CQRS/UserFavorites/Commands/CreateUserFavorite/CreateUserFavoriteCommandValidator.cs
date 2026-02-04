using FluentValidation;

namespace MelodyHub.Application.CQRS.UserFavorites.Commands.CreateUserFavorite;

public class CreateUserFavoriteCommandValidator 
    : AbstractValidator<CreateUserFavoriteCommand>
{
    public CreateUserFavoriteCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEqual(Guid.Empty)
            .WithMessage("User Id must not be empty");

        RuleFor(x => x.UserId)
            .NotEqual(Guid.Empty)
            .WithMessage("Instrument Id must not be empty");
    }
}