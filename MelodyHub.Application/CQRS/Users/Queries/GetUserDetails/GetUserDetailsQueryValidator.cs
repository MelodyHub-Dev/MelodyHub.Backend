using FluentValidation;

namespace MelodyHub.Application.CQRS.Users.Queries.GetUserDetails;

public class GetUserDetailsQueryValidator 
    : AbstractValidator<GetUserDetailsQuery>
{
    public GetUserDetailsQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("User Id must not be empty");
    }
}