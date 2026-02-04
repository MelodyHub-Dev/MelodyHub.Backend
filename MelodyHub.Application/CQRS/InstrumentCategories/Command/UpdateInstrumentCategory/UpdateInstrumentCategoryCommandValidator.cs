using FluentValidation;

namespace MelodyHub.Application.CQRS.InstrumentCategories.Command.UpdateInstrumentCategory;

public class UpdateInstrumentCategoryCommandValidator
    : AbstractValidator<UpdateInstrumentCategoryCommand>
{
    public UpdateInstrumentCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("User Id must not be empty");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required")
            .MaximumLength(100).WithMessage("Category name must not exceed 100 characters")
            .MinimumLength(2).WithMessage("Category name must be at least 2 characters long");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters")
            .When(x => !string.IsNullOrEmpty(x.Description));

        RuleFor(x => x.Slug)
            .NotEmpty().WithMessage("Slug is required")
            .MaximumLength(100).WithMessage("Slug must not exceed 100 characters")
            .Matches(@"^[a-z0-9]+(?:-[a-z0-9]+)*$").WithMessage("Slug must contain only lowercase letters, numbers, and hyphens")
            .MinimumLength(2).WithMessage("Slug must be at least 2 characters long");
    }
}