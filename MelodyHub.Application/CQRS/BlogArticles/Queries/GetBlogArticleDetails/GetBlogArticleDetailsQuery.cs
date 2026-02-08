using MediatR;

namespace MelodyHub.Application.CQRS.BlogArticles.Queries.GetBlogArticleDetails;

public class GetBlogArticleDetailsQuery : IRequest<BlogArticleDetailsVm>
{
    public Guid BlogArticleId { get; set; }
}
