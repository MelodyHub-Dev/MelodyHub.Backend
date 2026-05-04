using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.BlogArticles.Commands.CreateBlogArticle;

public class CreateBlogArticleCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<CreateBlogArticleCommand, Guid>
{
    public async Task<Guid> Handle(CreateBlogArticleCommand request, CancellationToken cancellationToken)
    {
        var author = await context.Users
            .FindAsync([request.AuthorId], cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.AuthorId);

        var newBlogArticle = new BlogArticle
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Content = request.Content,
            Excerpt = request.Excerpt,
            AuthorId = author.Id,
            ImageUrl = request.ImageUrl,
            IsPublished = true,
            PublishedAt = DateTime.UtcNow,
            ViewsCount = 0,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null,
        };

        await context.BlogArticles.AddAsync(newBlogArticle, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newBlogArticle.Id;
    }
}
