using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MelodyHub.Application.CQRS.BlogArticles.Queries.GetBlogArticlesList;
using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.BlogArticles.Queries.GetAllBlogArticles;

public class GetAllBlogArticlesQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetAllBlogArticlesQuery, BlogArticleListVm>
{
    public async Task<BlogArticleListVm> Handle(GetAllBlogArticlesQuery request, CancellationToken cancellationToken)
    {
        var query = context.BlogArticles.AsQueryable();

        if (request.IsPublished.HasValue)
        {
            query = query.Where(x => x.IsPublished == request.IsPublished.Value);
        }

        var blogArticles = await query
            .Select(x => new BlogArticleListLookupDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                Excerpt = x.Excerpt,
                AuthorId = x.AuthorId,
                AuthorName = x.Author.Username,
                ImageUrl = x.ImageUrl,
                ViewsCount = x.ViewsCount,
                IsPublished = x.IsPublished,
                PublishedAt = x.PublishedAt,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                IsNew = x.CreatedAt > DateTime.UtcNow.AddDays(-7),
                CommentCount = x.Comments.Count(c => c.IsApproved)
            })
            .ToListAsync(cancellationToken);

        return new BlogArticleListVm { BlogArticles = blogArticles };
    }
}
