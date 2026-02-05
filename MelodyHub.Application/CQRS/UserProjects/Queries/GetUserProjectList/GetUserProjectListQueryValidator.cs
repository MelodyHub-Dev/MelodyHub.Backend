using FluentValidation;

namespace MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectList;

public class GetUserProjectListQueryValidator
    : AbstractValidator<GetUserProjectListQuery>
{
    public GetUserProjectListQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid user ID");
    }
}