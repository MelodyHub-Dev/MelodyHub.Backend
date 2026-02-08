using FluentValidation;

namespace MelodyHub.Application.CQRS.BlogArticles.Queries.GetBlogArticleDetails;

public class GetBlogArticleDetailsQueryValidator
    : AbstractValidator<GetBlogArticleDetailsQuery>
{
    public GetBlogArticleDetailsQueryValidator()
    {
        RuleFor(x => x.BlogArticleId)
            .NotEmpty().WithMessage("Blog article ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid blog article ID");

    }
}
