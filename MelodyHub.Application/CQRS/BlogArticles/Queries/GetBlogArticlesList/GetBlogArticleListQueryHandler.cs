using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.BlogArticles.Queries.GetBlogArticlesList;

public class GetBlogArticleListQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetBlogArticleListQuery, BlogArticleListVm>
{
    public async Task<BlogArticleListVm> Handle(GetBlogArticleListQuery request, CancellationToken cancellationToken)
    {
        var blogArticles = await context.BlogArticles
            .Where(x => x.AuthorId == request.AuthorId)
            .ProjectTo<BlogArticleListLookupDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new BlogArticleListVm { BlogArticles = blogArticles };
    }
}