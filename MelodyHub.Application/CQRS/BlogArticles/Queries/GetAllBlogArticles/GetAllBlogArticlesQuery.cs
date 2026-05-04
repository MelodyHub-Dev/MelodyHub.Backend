using MediatR;
using MelodyHub.Application.CQRS.BlogArticles.Queries.GetBlogArticlesList;

namespace MelodyHub.Application.CQRS.BlogArticles.Queries.GetAllBlogArticles;

public class GetAllBlogArticlesQuery : IRequest<BlogArticleListVm>
{
}
