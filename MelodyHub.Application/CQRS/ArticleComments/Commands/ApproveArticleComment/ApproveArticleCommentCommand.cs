using MediatR;

namespace MelodyHub.Application.CQRS.ArticleComments.Commands.ApproveArticleComment;

public class ApproveArticleCommentCommand : IRequest
{
    public Guid Id { get; set; }
}
