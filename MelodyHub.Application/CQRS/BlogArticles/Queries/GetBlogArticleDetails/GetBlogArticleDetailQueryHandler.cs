using AutoMapper;
using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.BlogArticles.Queries.GetBlogArticleDetails;

public class GetBlogArticleDetailQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetBlogArticleDetailsQuery, BlogArticleDetailsVm>
{
    public async Task<BlogArticleDetailsVm> Handle(GetBlogArticleDetailsQuery request, CancellationToken cancellationToken)
    {
        var blogArticle = await context.BlogArticles
            .Include(x => x.Author)
            .FirstOrDefaultAsync(x => x.Id == request.BlogArticleId, cancellationToken)
            ?? throw new NotFoundException(nameof(BlogArticle), request.BlogArticleId);

        var result = new BlogArticleDetailsVm
        {
            Id = blogArticle.Id,
            Title = blogArticle.Title,
            Content = blogArticle.Content,
            Excerpt = blogArticle.Excerpt,
            AuthorId = blogArticle.AuthorId,
            AuthorName = blogArticle.Author.Username,
            ImageUrl = blogArticle.ImageUrl,
            ViewsCount = blogArticle.ViewsCount,
            IsPublished = blogArticle.IsPublished,
            PublishedAt = blogArticle.PublishedAt,
            CreatedAt = blogArticle.CreatedAt,
            UpdatedAt = blogArticle.UpdatedAt,
            IsNew = blogArticle.CreatedAt > DateTime.UtcNow.AddDays(-7),
            CommentCount = blogArticle.Comments.Count(c => c.IsApproved)
        };

        return result;
    }
}
