using MediatR;
using MelodyHub.Application.Interfaces;

namespace MelodyHub.Application.CQRS.ArticleComments.Commands.ApproveArticleComment;

public class ApproveArticleCommentCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<ApproveArticleCommentCommand>
{
    public async Task Handle(ApproveArticleCommentCommand request, CancellationToken cancellationToken)
    {
        var articleComment = await context.ArticleComments.FindAsync(new object[] { request.Id }, cancellationToken);
        if (articleComment == null)
        {
            throw new InvalidOperationException("Комментарий не найден");
        }

        articleComment.IsApproved = true;
        await context.SaveChangesAsync(cancellationToken);
    }
}
