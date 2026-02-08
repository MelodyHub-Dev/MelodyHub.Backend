using FluentValidation;

namespace MelodyHub.Application.CQRS.ArticleComments.Commands.DeleteArticleComment;

public class DeleteArticleCommentCommandValidator 
    : AbstractValidator<DeleteArticleCommentCommand>
{
    public DeleteArticleCommentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Comment Id must not be empty");
    }
}
