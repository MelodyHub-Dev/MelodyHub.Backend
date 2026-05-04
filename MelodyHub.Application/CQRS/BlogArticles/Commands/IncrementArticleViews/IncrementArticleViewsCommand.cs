using MediatR;

namespace MelodyHub.Application.CQRS.BlogArticles.Commands.IncrementArticleViews;

public class IncrementArticleViewsCommand : IRequest
{
    public Guid ArticleId { get; set; }
}