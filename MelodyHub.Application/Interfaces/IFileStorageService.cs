namespace MelodyHub.Application.Interfaces;

public interface IFileStorageService
{
    /// <summary>Сохраняет файл и возвращает публичный URL</summary>
    Task<string> SaveAvatarAsync(Guid userId, Stream stream, string fileName, CancellationToken ct = default);

    /// <summary>Удаляет файл по URL (если существует)</summary>
    Task DeleteAvatarAsync(string? avatarUrl, CancellationToken ct = default);

    /// <summary>Сохраняет изображение статьи и возвращает публичный URL</summary>
    Task<string> SaveArticleImageAsync(Guid articleId, Stream stream, string fileName, CancellationToken ct = default);

    /// <summary>Удаляет изображение статьи по URL (если существует)</summary>
    Task DeleteArticleImageAsync(string? imageUrl, CancellationToken ct = default);
}
