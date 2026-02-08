using MediatR;

namespace MelodyHub.Application.CQRS.BlogArticles.Commands.DeleteBlogArticle;

public class DeleteBlogArticleCommand : IRequest
{
    public Guid Id { get; set; }
}