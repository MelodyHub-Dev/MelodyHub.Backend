using FluentValidation;
using MelodyHub.Application.CQRS.UserFavorites.Commands.CreateUserFavorite;

namespace MelodyHub.Application.CQRS.UserFavorites.Commands.DeleteUserFavorite;

public class DeleteUserFavoriteCommandValidator
    : AbstractValidator<CreateUserFavoriteCommand>
{
    public DeleteUserFavoriteCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEqual(Guid.Empty)
            .WithMessage("User Id must not be empty");

        RuleFor(x => x.UserId)
            .NotEqual(Guid.Empty)
            .WithMessage("Instrument Id must not be empty");
    }
}