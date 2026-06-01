using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MelodyHub.Application.Interfaces;
using MelodyHub.Application.CQRS.ArticleComments.Queries.GetArticleCommentList;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.ArticleComments.Queries.GetPendingArticleCommentList;

public class GetPendingArticleCommentListQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetPendingArticleCommentListQuery, ArticleCommentListVm>
{
    public async Task<ArticleCommentListVm> Handle(GetPendingArticleCommentListQuery request, CancellationToken cancellationToken)
    {
        var articleComments = await context.ArticleComments
            .Where(x => !x.IsApproved)
            .Include(x => x.User)
            .Include(x => x.Article)
            .OrderByDescending(x => x.CreatedAt)
            .ProjectTo<ArticleCommentListLookupDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ArticleCommentListVm { Comments = articleComments };
    }
}
