using FluentValidation;

namespace MelodyHub.Application.CQRS.BlogArticles.Queries.GetBlogArticlesList;

public class GetBlogArticleListQueryValidator 
    : AbstractValidator<GetBlogArticleListQuery>
{
    public GetBlogArticleListQueryValidator()
    {
        RuleFor(x => x.AuthorId)
            .NotEmpty().WithMessage("Author ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid author ID");
    }
}