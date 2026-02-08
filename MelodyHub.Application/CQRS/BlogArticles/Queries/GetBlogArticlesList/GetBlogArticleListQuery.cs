using MediatR;

namespace MelodyHub.Application.CQRS.BlogArticles.Queries.GetBlogArticlesList;

public class GetBlogArticleListQuery : IRequest<BlogArticleListVm>
{
    public Guid AuthorId { get; set; }
}