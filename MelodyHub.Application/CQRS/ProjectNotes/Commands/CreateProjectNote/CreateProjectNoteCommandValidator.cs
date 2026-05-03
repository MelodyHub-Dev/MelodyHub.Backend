using FluentValidation;

namespace MelodyHub.Application.CQRS.ProjectNotes.Commands.CreateProjectNote;

public class CreateProjectNoteCommandValidator : AbstractValidator<CreateProjectNoteCommand>
{
    public CreateProjectNoteCommandValidator()
    {
        RuleFor(x => x.UserProjectId)
            .NotEmpty().WithMessage("Project ID is required");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required")
            .MaximumLength(2000).WithMessage("Content is too long");
    }
}
