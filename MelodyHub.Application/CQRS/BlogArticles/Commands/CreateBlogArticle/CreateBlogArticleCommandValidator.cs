using FluentValidation;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.BlogArticles.Commands.CreateBlogArticle;

public class CreateBlogArticleCommandValidator : AbstractValidator<BlogArticle>
{
    public CreateBlogArticleCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Article title is required")
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters")
            .MinimumLength(5).WithMessage("Title must be at least 5 characters long");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Article content is required")
            .MinimumLength(100).WithMessage("Content must be at least 100 characters long")
            .MaximumLength(10000).WithMessage("Content cannot exceed 10,000 characters");

        RuleFor(x => x.Excerpt)
            .MaximumLength(500).WithMessage("Excerpt cannot exceed 500 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.Excerpt));

        RuleFor(x => x.AuthorId)
            .NotEmpty().WithMessage("Author is required");

        RuleFor(x => x.ImageUrl)
            .MaximumLength(500).WithMessage("Image URL is too long")
            .When(x => !string.IsNullOrWhiteSpace(x.ImageUrl))
            .Must(BeValidUrl).WithMessage("Invalid image URL format")
            .When(x => !string.IsNullOrWhiteSpace(x.ImageUrl));
    }

    private bool BeValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}