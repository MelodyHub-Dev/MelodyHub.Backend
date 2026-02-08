using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.ArticleComments.Commands.DeleteArticleComment;

public class DeleteArticleCommentCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<DeleteArticleCommentCommand>
{
    public async Task Handle(DeleteArticleCommentCommand request, CancellationToken cancellationToken)
    {
        var articleComment = await context.ArticleComments
            .FindAsync([request.Id],cancellationToken)
            ?? throw new NotFoundException(nameof(ArticleComment), request.Id);

        context.ArticleComments.Remove(articleComment);

        await context.SaveChangesAsync(cancellationToken);
    }
}