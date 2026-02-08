using AutoMapper;
using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.BlogArticles.Queries.GetBlogArticleDetails;

public class GetBlogArticleDetailQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetBlogArticleDetailsQuery, BlogArticleDetailsVm>
{
    public async Task<BlogArticleDetailsVm> Handle(GetBlogArticleDetailsQuery request, CancellationToken cancellationToken)
    {
        var blogArticle = await context.BlogArticles
            .FindAsync([request.BlogArticleId], cancellationToken)
            ?? throw new NotFoundException(nameof(BlogArticle), request.BlogArticleId);

        return mapper.Map<BlogArticleDetailsVm>(blogArticle);
    }
}
