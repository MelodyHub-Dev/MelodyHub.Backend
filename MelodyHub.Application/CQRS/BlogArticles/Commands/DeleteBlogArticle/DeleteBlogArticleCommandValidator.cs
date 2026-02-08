using FluentValidation;

namespace MelodyHub.Application.CQRS.BlogArticles.Commands.DeleteBlogArticle;

public class DeleteBlogArticleCommandValidator
    : AbstractValidator<DeleteBlogArticleCommand>
{
    public DeleteBlogArticleCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("BlogArticle Id must not be empty");
    }
}