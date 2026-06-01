using FluentValidation;

namespace MelodyHub.Application.CQRS.ArticleComments.Commands.ApproveArticleComment;

public class ApproveArticleCommentCommandValidator : AbstractValidator<ApproveArticleCommentCommand>
{
    public ApproveArticleCommentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Comment Id must not be empty");
    }
}
