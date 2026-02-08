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

        blogArticle.Title = request.Title;
        blogArticle.Content = request.Content;
        blogArticle.Excerpt = request.Excerpt;
        blogArticle.ImageUrl = request.ImageUrl;
        blogArticle.ViewsCount = request.ViewsCount;
        blogArticle.IsPublished = request.IsPublished;

        if(blogArticle.IsPublished)
            blogArticle.PublishedAt = DateTime.UtcNow;
        
        blogArticle.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);
    }
}
