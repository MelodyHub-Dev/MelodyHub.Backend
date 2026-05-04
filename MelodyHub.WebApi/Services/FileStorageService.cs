using MelodyHub.Application.Interfaces;

namespace MelodyHub.WebApi.Services;

public class FileStorageService(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
    : IFileStorageService
{
    private const string AvatarsFolder = "avatars";
    private const string ArticlesFolder = "articles";

    public async Task<string> SaveAvatarAsync(
        Guid userId, Stream stream, string fileName, CancellationToken ct = default)
    {
        var ext = Path.GetExtension(fileName).ToLowerInvariant();
        if (string.IsNullOrEmpty(ext)) ext = ".jpg";

        var dir = Path.Combine(env.WebRootPath, AvatarsFolder);
        Directory.CreateDirectory(dir);

        var storedName = $"{userId}{ext}";
        var fullPath = Path.Combine(dir, storedName);

        await using var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
        await stream.CopyToAsync(fs, ct);

        // Строим публичный URL: https://host/avatars/userId.ext
        var request = httpContextAccessor.HttpContext?.Request;
        var baseUrl = request is not null
            ? $"{request.Scheme}://{request.Host}"
            : string.Empty;

        return $"{baseUrl}/{AvatarsFolder}/{storedName}";
    }

    public Task DeleteAvatarAsync(string? avatarUrl, CancellationToken ct = default)
    {
        if (string.IsNullOrEmpty(avatarUrl)) return Task.CompletedTask;

        try
        {
            // Извлекаем имя файла из URL
            var fileName = Path.GetFileName(new Uri(avatarUrl).LocalPath);
            var fullPath = Path.Combine(env.WebRootPath, AvatarsFolder, fileName);
            if (File.Exists(fullPath)) File.Delete(fullPath);
        }
        catch { /* игнорируем ошибки удаления */ }

        return Task.CompletedTask;
    }

    public async Task<string> SaveArticleImageAsync(
        Guid articleId, Stream stream, string fileName, CancellationToken ct = default)
    {
        var ext = Path.GetExtension(fileName).ToLowerInvariant();
        if (string.IsNullOrEmpty(ext)) ext = ".jpg";

        var dir = Path.Combine(env.WebRootPath, ArticlesFolder);
        Directory.CreateDirectory(dir);

        var storedName = $"{articleId}{ext}";
        var fullPath = Path.Combine(dir, storedName);

        await using var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
        await stream.CopyToAsync(fs, ct);

        var request = httpContextAccessor.HttpContext?.Request;
        var baseUrl = request is not null
            ? $"{request.Scheme}://{request.Host}"
            : string.Empty;

        return $"{baseUrl}/{ArticlesFolder}/{storedName}";
    }

    public Task DeleteArticleImageAsync(string? imageUrl, CancellationToken ct = default)
    {
        if (string.IsNullOrEmpty(imageUrl)) return Task.CompletedTask;

        try
        {
            var fileName = Path.GetFileName(new Uri(imageUrl).LocalPath);
            var fullPath = Path.Combine(env.WebRootPath, ArticlesFolder, fileName);
            if (File.Exists(fullPath)) File.Delete(fullPath);
        }
        catch { /* игнорируем ошибки удаления */ }

        return Task.CompletedTask;
    }
}
