using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.BlogArticles.Commands.IncrementArticleViews;

public class IncrementArticleViewsCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<IncrementArticleViewsCommand>
{
    public async Task Handle(IncrementArticleViewsCommand request, CancellationToken cancellationToken)
    {
        var blogArticle = await context.BlogArticles
            .FindAsync([request.ArticleId], cancellationToken)
            ?? throw new NotFoundException(nameof(BlogArticle), request.ArticleId);

        blogArticle.ViewsCount++;
        await context.SaveChangesAsync(cancellationToken);
    }
}