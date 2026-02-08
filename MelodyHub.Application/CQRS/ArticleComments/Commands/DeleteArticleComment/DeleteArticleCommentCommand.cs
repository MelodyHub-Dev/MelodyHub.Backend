using MediatR;

namespace MelodyHub.Application.CQRS.ArticleComments.Commands.DeleteArticleComment;

public class DeleteArticleCommentCommand : IRequest
{
    public Guid Id { get; set; }
}
