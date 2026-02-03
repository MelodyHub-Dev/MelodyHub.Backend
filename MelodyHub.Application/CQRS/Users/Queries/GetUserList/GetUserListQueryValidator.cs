using FluentValidation;

namespace MelodyHub.Application.CQRS.Users.Queries.GetUserList;

public class GetUserListQueryValidator 
    : AbstractValidator<GetUserListQuery>
{
    public GetUserListQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("User Id must not be empty");
    }
}