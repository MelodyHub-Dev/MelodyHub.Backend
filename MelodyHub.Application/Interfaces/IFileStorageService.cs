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

    /// <summary>Сохраняет изображение инструмента и возвращает публичный URL</summary>
    Task<string> SaveInstrumentImageAsync(Guid instrumentId, Stream stream, string fileName, CancellationToken ct = default);

    /// <summary>Удаляет изображение инструмента по URL (если существует)</summary>
    Task DeleteInstrumentImageAsync(string? imageUrl, CancellationToken ct = default);

    /// <summary>Сохраняет изображение шага инструкции (blueprint) и возвращает публичный URL</summary>
    Task<string> SaveBlueprintImageAsync(Guid blueprintId, Stream stream, string fileName, CancellationToken ct = default);

    /// <summary>Удаляет изображение шага инструкции по URL (если существует)</summary>
    Task DeleteBlueprintImageAsync(string? imageUrl, CancellationToken ct = default);

    /// <summary>Сохраняет изображение материала и возвращает публичный URL</summary>
    Task<string> SaveMaterialImageAsync(Guid materialId, Stream stream, string fileName, CancellationToken ct = default);

    /// <summary>Удаляет изображение материала по URL (если существует)</summary>
    Task DeleteMaterialImageAsync(string? imageUrl, CancellationToken ct = default);

    /// <summary>Сохраняет видео шага инструкции и возвращает публичный URL</summary>
    Task<string> SaveBlueprintVideoAsync(Guid blueprintId, Stream stream, string fileName, CancellationToken ct = default);

    /// <summary>Удаляет видео шага инструкции по URL (если существует)</summary>
    Task DeleteBlueprintVideoAsync(string? videoUrl, CancellationToken ct = default);
}
