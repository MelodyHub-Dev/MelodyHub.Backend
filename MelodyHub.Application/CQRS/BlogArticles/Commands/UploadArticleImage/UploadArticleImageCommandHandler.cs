using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.BlogArticles.Commands.UploadArticleImage;

public class UploadArticleImageCommandHandler(
    IMelodyHubDbContext context,
    IFileStorageService fileStorage)
    : IRequestHandler<UploadArticleImageCommand, string>
{
    private static readonly string[] AllowedTypes = ["image/jpeg", "image/png", "image/webp", "image/gif"];
    private const long MaxBytes = 10 * 1024 * 1024; // 10 MB

    public async Task<string> Handle(UploadArticleImageCommand request, CancellationToken cancellationToken)
    {
        if (!AllowedTypes.Contains(request.ContentType))
            throw new BadRequestException("Допустимые форматы: JPEG, PNG, WebP, GIF");

        if (request.FileStream.Length > MaxBytes)
            throw new BadRequestException("Размер файла не должен превышать 10 МБ");

        var article = await context.BlogArticles.FindAsync([request.ArticleId], cancellationToken)
            ?? throw new NotFoundException(nameof(BlogArticle), request.ArticleId);

        // Удаляем старое изображение если есть
        await fileStorage.DeleteArticleImageAsync(article.ImageUrl, cancellationToken);

        var url = await fileStorage.SaveArticleImageAsync(
            request.ArticleId, request.FileStream, request.FileName, cancellationToken);

        article.ImageUrl = url;
        article.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return url;
    }
}