using MediatR;

namespace MelodyHub.Application.CQRS.BlogArticles.Commands.CreateBlogArticle;

public class CreateBlogArticleCommand : IRequest<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Excerpt { get; set; }
    public Guid AuthorId { get; set; }
    public string? ImageUrl { get; set; }
}
