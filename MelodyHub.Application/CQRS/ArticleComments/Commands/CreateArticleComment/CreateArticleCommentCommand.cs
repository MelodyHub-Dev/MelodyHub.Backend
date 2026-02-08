using MediatR;

namespace MelodyHub.Application.CQRS.ArticleComments.Commands.CreateArticleComment;

public class CreateArticleCommentCommand : IRequest<Guid>
{
    public Guid ArticleId { get; set; }
    public Guid UserId { get; set; }
    public Guid? ParentCommentId { get; set; }
    public string Content { get; set; } = string.Empty;
}
