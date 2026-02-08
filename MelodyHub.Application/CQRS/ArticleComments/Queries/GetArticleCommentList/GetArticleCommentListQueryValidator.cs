using FluentValidation;

namespace MelodyHub.Application.CQRS.ArticleComments.Queries.GetArticleCommentList;

public class GetArticleCommentListQueryValidator
    : AbstractValidator<GetArticleCommentListQuery>
{
    public GetArticleCommentListQueryValidator()
    {
        RuleFor(x => x.ArticleId)
           .NotEqual(Guid.Empty)
           .WithMessage("Blog article Id must not be empty");
    }
}