using MediatR;

namespace MelodyHub.Application.CQRS.BlogArticles.Commands.UploadArticleImage;

public class UploadArticleImageCommand : IRequest<string>
{
    public Guid ArticleId { get; set; }
    public Stream FileStream { get; set; } = null!;
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
}