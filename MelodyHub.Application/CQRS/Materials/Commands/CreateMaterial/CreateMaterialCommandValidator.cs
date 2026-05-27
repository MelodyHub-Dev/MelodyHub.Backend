using FluentValidation;

namespace MelodyHub.Application.CQRS.Materials.Commands.CreateMaterial;

public class CreateMaterialCommandValidator
    : AbstractValidator<CreateMaterialCommand>
{
    public CreateMaterialCommandValidator()
    {
        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Material name is required")
            .MaximumLength(200).WithMessage("Material name must not exceed 200 characters")
            .MinimumLength(2).WithMessage("Material name must be at least 2 characters long")
            .Matches(@"^[\p{L}0-9\s\-_,.()&/]+$")
            .WithMessage("Material name can only contain letters, numbers, spaces, hyphens, commas, periods, parentheses, ampersands, and forward slashes");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));

        RuleFor(x => x.Unit)
            .IsInEnum().WithMessage("Invalid material unit");

        RuleFor(x => x.AvgPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Average price must be zero or positive")
            .LessThanOrEqualTo(1000000).WithMessage("Average price must not exceed 1,000,000")
            .PrecisionScale(12, 2, false)
            .WithMessage("Average price must have maximum 12 digits with 2 decimal places");

        RuleFor(x => x.Category)
            .MaximumLength(100).WithMessage("Category must not exceed 100 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.Category))
            .Matches(@"^[\p{L}0-9\s\-_&]+$")
            .WithMessage("Category can only contain letters, numbers, spaces, hyphens, underscores, and ampersands")
            .When(x => !string.IsNullOrWhiteSpace(x.Category));
    }
}