using MediatR;

namespace MelodyHub.Application.CQRS.ArticleComments.Queries.GetArticleCommentList;

public class GetArticleCommentListQuery : IRequest<ArticleCommentListVm>
{
    public Guid ArticleId { get; set; }
}
