using FluentValidation;

namespace MelodyHub.Application.CQRS.BlogArticles.Commands.UpdateBlogArticle;

public class UpdateBlogArticleCommandValidator
    : AbstractValidator<UpdateBlogArticleCommand>
{
    public UpdateBlogArticleCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Article ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid article ID");

        RuleFor(x => x.Title)
            .Cascade(CascadeMode.Stop)
            .MaximumLength(200).WithMessage("Article title must not exceed 200 characters")
            .MinimumLength(3).WithMessage("Article title must be at least 3 characters long")
            .When(x => !string.IsNullOrWhiteSpace(x.Title))
            .Matches(@"^[a-zA-Zа-яА-Я0-9\s\-_&.,'()!?:]+$")
            .WithMessage("Article title contains invalid characters")
            .When(x => !string.IsNullOrWhiteSpace(x.Title));

        RuleFor(x => x.Content)
            .Cascade(CascadeMode.Stop)
            .MaximumLength(10000).WithMessage("Content must not exceed 10,000 characters")
            .MinimumLength(100).WithMessage("Content must be at least 100 characters long")
            .When(x => !string.IsNullOrWhiteSpace(x.Content));

        RuleFor(x => x.Excerpt)
            .MaximumLength(500).WithMessage("Excerpt must not exceed 500 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.Excerpt))
            .MinimumLength(20).WithMessage("Excerpt must be at least 20 characters long")
            .When(x => !string.IsNullOrWhiteSpace(x.Excerpt) && x.Excerpt.Length > 0);

        RuleFor(x => x.ImageUrl)
            .MaximumLength(500).WithMessage("Image URL must not exceed 500 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.ImageUrl));

        RuleFor(x => x.ViewsCount)
            .GreaterThanOrEqualTo(0).WithMessage("Views count cannot be negative")
            .When(x => x.ViewsCount > 0);

        RuleFor(x => x.IsPublished)
            .NotNull().WithMessage("IsPublished flag is required");
    }
}
