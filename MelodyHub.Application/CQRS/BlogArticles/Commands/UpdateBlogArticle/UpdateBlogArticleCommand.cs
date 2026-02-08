using MediatR;

namespace MelodyHub.Application.CQRS.BlogArticles.Commands.UpdateBlogArticle;

public class UpdateBlogArticleCommand : IRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Excerpt { get; set; }
    public string? ImageUrl { get; set; }
    public int ViewsCount { get; set; }
    public bool IsPublished { get; set; }
}
