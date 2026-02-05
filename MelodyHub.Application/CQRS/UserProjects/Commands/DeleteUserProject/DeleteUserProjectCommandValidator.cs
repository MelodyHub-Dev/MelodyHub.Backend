using FluentValidation;

namespace MelodyHub.Application.CQRS.UserProjects.Commands.DeleteUserProject;

public class DeleteUserProjectCommandValidator
    : AbstractValidator<DeleteUserProjectCommand>
{
    public DeleteUserProjectCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("UserProject ID is required");
    }
}
