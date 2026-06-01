using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.BlogArticles.Commands.UpdateBlogArticle;

public class UpdateBlogArticleCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<UpdateBlogArticleCommand>
{
    public async Task Handle(UpdateBlogArticleCommand request, CancellationToken cancellationToken)
    {
        var blogArticle = await context.BlogArticles
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(BlogArticle), request.Id);

        // Обновляем только если значение предоставлено и отличается
        if (!string.IsNullOrEmpty(request.Title))
            blogArticle.Title = request.Title;

        if (!string.IsNullOrEmpty(request.Content))
            blogArticle.Content = request.Content;

        if (request.Excerpt != null)
            blogArticle.Excerpt = request.Excerpt;

        if (request.ImageUrl != null)
            blogArticle.ImageUrl = request.ImageUrl;

        // ViewsCount и IsPublished обновляем только если явно переданы.
        if (request.ViewsCount > 0)
            blogArticle.ViewsCount = request.ViewsCount;

        if (request.IsPublished.HasValue)
        {
            blogArticle.IsPublished = request.IsPublished.Value;

            if (blogArticle.IsPublished && blogArticle.PublishedAt == null)
                blogArticle.PublishedAt = DateTime.UtcNow;
        }

        blogArticle.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);
    }
}
