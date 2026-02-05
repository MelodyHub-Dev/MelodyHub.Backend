using FluentValidation;
using MelodyHub.Domain.Enums;

namespace MelodyHub.Application.CQRS.UserProjects.Commands.CreateUserProject;

public class CreateUserProjectCommandValidator
    : AbstractValidator<CreateUserProjectCommand>
{
    public CreateUserProjectCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required");

        RuleFor(x => x.InstrumentId)
            .NotEmpty().WithMessage("Instrument ID is required");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name is too long");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid status");

        RuleFor(x => x.Progress)
            .InclusiveBetween((byte)0, (byte)100).WithMessage("Progress must be 0-100%");

        RuleFor(x => x.Status)
            .Equal(ProjectStatus.Planned)
            .When(x => x.Status != ProjectStatus.InProgress)
            .WithMessage("New projects should be Planned by default");

        RuleFor(x => x.Progress)
            .Equal((byte)0)
            .When(x => x.Status == ProjectStatus.Planned)
            .WithMessage("Planned projects should have 0% progress");
    }
}