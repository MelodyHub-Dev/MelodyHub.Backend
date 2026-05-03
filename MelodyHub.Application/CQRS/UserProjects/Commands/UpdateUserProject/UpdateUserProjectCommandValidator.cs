using FluentValidation;
using MelodyHub.Domain.Enums;

namespace MelodyHub.Application.CQRS.UserProjects.Commands.UpdateUserProject;

public class UpdateUserProjectCommandValidator
    : AbstractValidator<UpdateUserProjectCommand>
{
    public UpdateUserProjectCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Project ID is required");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name is too long");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid status");

        RuleFor(x => x.Progress)
            .InclusiveBetween((byte)0, (byte)100).WithMessage("Progress must be 0-100%");
    }
}
