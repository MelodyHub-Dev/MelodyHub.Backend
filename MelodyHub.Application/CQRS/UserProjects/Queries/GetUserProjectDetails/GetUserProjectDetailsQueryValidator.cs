using FluentValidation;

namespace MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectDetails;

public class GetUserProjectDetailsQueryValidator
    : AbstractValidator<GetUserProjectDetailsQuery>
{
    public GetUserProjectDetailsQueryValidator()
    {
        RuleFor(x => x.UserProjectId)
            .NotEmpty().WithMessage("Project ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid project ID");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid user ID");
    }
}