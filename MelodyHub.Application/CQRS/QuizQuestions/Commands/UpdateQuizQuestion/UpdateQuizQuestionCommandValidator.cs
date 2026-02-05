using FluentValidation;

namespace MelodyHub.Application.CQRS.QuizQuestions.Commands.UpdateQuizQuestion;

public class UpdateQuizQuestionCommandValidator
    : AbstractValidator<UpdateQuizQuestionCommand>
{
    public UpdateQuizQuestionCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Quiz question Id must not be empty");

        RuleFor(x => x.QuestionText)
            .NotEmpty().WithMessage("Question text is required")
            .MaximumLength(500).WithMessage("Question text is too long");

        RuleFor(x => x.OptionA)
            .NotEmpty().WithMessage("Option A is required")
            .MaximumLength(200).WithMessage("Option A is too long");

        RuleFor(x => x.OptionB)
            .NotEmpty().WithMessage("Option B is required")
            .MaximumLength(200).WithMessage("Option B is too long");

        RuleFor(x => x.CorrectAnswer)
            .Must(c => char.ToLower(c) is 'a' or 'b' or 'c' or 'd')
            .WithMessage("Correct answer must be 'a', 'b', 'c' or 'd'");

        RuleFor(x => x)
            .Must(q => q.CorrectAnswer == 'c' ? !string.IsNullOrEmpty(q.OptionC) : true)
            .WithMessage("Option C is required when correct answer is 'c'");

        RuleFor(x => x)
            .Must(q => q.CorrectAnswer != 'd' || !string.IsNullOrEmpty(q.OptionD))
            .WithMessage("Option D is required when correct answer is 'd'");

        RuleFor(x => x.Points)
            .InclusiveBetween((byte)1, (byte)100).WithMessage("Points must be between 1 and 100");
    }
}