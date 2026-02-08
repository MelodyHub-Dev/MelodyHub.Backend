using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.ArticleComments.Commands.UpdateArticleComment;

public class UpdateArticleCommentCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<UpdateArticleCommentCommand>
{
    public async Task Handle(UpdateArticleCommentCommand request, CancellationToken cancellationToken)
    {
        var articleComment = await context.ArticleComments
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(ArticleComment), request.Id);

        articleComment.Content = request.Content;
        articleComment.IsApproved = request.IsApproved;

        await context.SaveChangesAsync(cancellationToken);
    }
}
