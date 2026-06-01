using MediatR;
using MelodyHub.Application.CQRS.ArticleComments.Queries.GetArticleCommentList;

namespace MelodyHub.Application.CQRS.ArticleComments.Queries.GetPendingArticleCommentList;

public class GetPendingArticleCommentListQuery : IRequest<ArticleCommentListVm>
{
}
