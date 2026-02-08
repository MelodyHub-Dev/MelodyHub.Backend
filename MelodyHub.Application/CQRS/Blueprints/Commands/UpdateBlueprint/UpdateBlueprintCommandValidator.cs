using FluentValidation;

namespace MelodyHub.Application.CQRS.Blueprints.Commands.UpdateBlueprint;

public class UpdateBlueprintCommandValidator
    : AbstractValidator<UpdateBlueprintCommand>
{
    public UpdateBlueprintCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Blueprint Id must not be empty");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(200).WithMessage("Title is too long");

        RuleFor(x => x.StepNumber)
            .GreaterThan(0).WithMessage("Step number must be positive");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required")
            .MaximumLength(5000).WithMessage("Content is too long");

        RuleFor(x => x.ImageUrl)
            .MaximumLength(500).WithMessage("Image URL is too long")
            .When(x => !string.IsNullOrWhiteSpace(x.ImageUrl));

        RuleFor(x => x.VideoUrl)
            .MaximumLength(500).WithMessage("Video URL is too long")
            .When(x => !string.IsNullOrWhiteSpace(x.VideoUrl));

        RuleFor(x => x.EstimatedTimeMinutes)
            .GreaterThan(0).WithMessage("Time must be positive")
            .When(x => x.EstimatedTimeMinutes.HasValue);
    }
}