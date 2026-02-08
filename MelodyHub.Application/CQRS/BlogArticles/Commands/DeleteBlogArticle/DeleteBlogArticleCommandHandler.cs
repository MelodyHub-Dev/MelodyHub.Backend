using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.BlogArticles.Commands.DeleteBlogArticle;

public class DeleteBlogArticleCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<DeleteBlogArticleCommand>
{
    public async Task Handle(DeleteBlogArticleCommand request, CancellationToken cancellationToken)
    {
        var blogArticle = await context.BlogArticles
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(BlogArticle), request.Id);

        context.BlogArticles.Remove(blogArticle);
        await context.SaveChangesAsync(cancellationToken);
    }
}
