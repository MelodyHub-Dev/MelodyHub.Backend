using FluentValidation;

namespace MelodyHub.Application.CQRS.Quizzes.Commands.CreateQuiz;

public class CreateQuizCommandValidator 
    : AbstractValidator<CreateQuizCommand>
{
    public CreateQuizCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(200).WithMessage("Title is too long");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description is too long")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));

        RuleFor(x => x.Difficulty)
            .IsInEnum().WithMessage("Invalid difficulty");

        RuleFor(x => x.IsActive)
            .NotNull().WithMessage("IsActive is required");
    }
}