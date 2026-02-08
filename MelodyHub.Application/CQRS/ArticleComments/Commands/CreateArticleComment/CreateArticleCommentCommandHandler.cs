using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.ArticleComments.Commands.CreateArticleComment;

public class CreateArticleCommentCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<CreateArticleCommentCommand, Guid>
{
    public async Task<Guid> Handle(CreateArticleCommentCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .FindAsync([request.UserId], cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.UserId);

        var article = await context.BlogArticles
            .FindAsync([request.ArticleId], cancellationToken)
            ?? throw new NotFoundException(nameof(BlogArticle), request.UserId);

        var newArticleComment = new ArticleComment
        {
            Id = Guid.NewGuid(),
            ArticleId = article.Id,
            UserId = user.Id,
            Content = request.Content,
            IsApproved = false,
            CreatedAt = DateTime.UtcNow,
        };

        await context.ArticleComments.AddAsync(newArticleComment, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newArticleComment.Id;
    }
}
