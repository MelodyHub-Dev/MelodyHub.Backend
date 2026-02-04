using FluentValidation;

namespace MelodyHub.Application.CQRS.Instruments.Commands.UpdateInstrument;

public class UpdateInstrumentCommandValidator
    : AbstractValidator<UpdateInstrumentCommand>
{
    public UpdateInstrumentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Instrument ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid instrument ID");

        RuleFor(x => x.Name)
            .MaximumLength(200).WithMessage("Instrument name must not exceed 200 characters")
            .MinimumLength(2).WithMessage("Instrument name must be at least 2 characters long")
            .When(x => !string.IsNullOrWhiteSpace(x.Name))
            .Matches(@"^[a-zA-Z0-9\s\-_&.,'()/]+$")
            .WithMessage("Name can only contain letters, numbers, spaces, hyphens, underscores, ampersands, dots, commas, apostrophes, parentheses, and forward slashes")
            .When(x => !string.IsNullOrWhiteSpace(x.Name));

        RuleFor(x => x.Description)
            .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters")
            .MinimumLength(20).WithMessage("Description must be at least 20 characters long")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));

        RuleFor(x => x.ShortDescription)
            .MaximumLength(500).WithMessage("Short description must not exceed 500 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.ShortDescription));

        RuleFor(x => x.Difficulty)
            .IsInEnum().WithMessage("Invalid difficulty level");

        RuleFor(x => x.EstimatedHours)
            .GreaterThan(0).WithMessage("Estimated hours must be greater than 0")
            .LessThanOrEqualTo(1000).WithMessage("Estimated hours must not exceed 1000")
            .When(x => x.EstimatedHours.HasValue);

        RuleFor(x => x.MainImageUrl)
            .MaximumLength(500).WithMessage("Image URL must not exceed 500 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.MainImageUrl))
            .Must(BeValidUrl).WithMessage("Invalid image URL format")
            .When(x => !string.IsNullOrWhiteSpace(x.MainImageUrl));

        RuleFor(x => x.ViewsCount)
            .GreaterThanOrEqualTo(0).WithMessage("Views count cannot be negative");

        RuleFor(x => x.CategoryId)
            .NotEqual(Guid.Empty).WithMessage("Invalid category ID");
    }

    private bool BeValidUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return true;

        return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}