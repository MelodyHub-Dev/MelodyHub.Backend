using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.ArticleComments.Queries.GetArticleCommentList;

public class GetArticleCommentListQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetArticleCommentListQuery, ArticleCommentListVm>
{
    public async Task<ArticleCommentListVm> Handle(GetArticleCommentListQuery request, CancellationToken cancellationToken)
    {
        var articleComments = await context.ArticleComments
            .Where(x => x.ArticleId == request.ArticleId)
            .ProjectTo<ArticleCommentListLookupDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ArticleCommentListVm { Comments = articleComments };
    }
}
