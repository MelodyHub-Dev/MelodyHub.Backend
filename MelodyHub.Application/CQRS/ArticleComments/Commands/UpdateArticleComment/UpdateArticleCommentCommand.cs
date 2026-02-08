using MediatR;

namespace MelodyHub.Application.CQRS.ArticleComments.Commands.UpdateArticleComment;

public class UpdateArticleCommentCommand : IRequest 
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UserId { get; set; }
    public Guid? ParentCommentId { get; set; }
    public string Content { get; set; } = string.Empty;
    public bool IsApproved { get; set; } 
}
