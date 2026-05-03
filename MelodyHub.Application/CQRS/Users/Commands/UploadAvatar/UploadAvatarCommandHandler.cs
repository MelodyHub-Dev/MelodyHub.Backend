using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Users.Commands.UploadAvatar;

public class UploadAvatarCommandHandler(
    IMelodyHubDbContext context,
    IFileStorageService fileStorage)
    : IRequestHandler<UploadAvatarCommand, string>
{
    private static readonly string[] AllowedTypes = ["image/jpeg", "image/png", "image/webp", "image/gif"];
    private const long MaxBytes = 5 * 1024 * 1024; // 5 MB

    public async Task<string> Handle(UploadAvatarCommand request, CancellationToken cancellationToken)
    {
        if (!AllowedTypes.Contains(request.ContentType))
            throw new BadRequestException("Допустимые форматы: JPEG, PNG, WebP, GIF");

        if (request.FileStream.Length > MaxBytes)
            throw new BadRequestException("Размер файла не должен превышать 5 МБ");

        var user = await context.Users.FindAsync([request.UserId], cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.UserId);

        // Удаляем старую аватарку
        await fileStorage.DeleteAvatarAsync(user.AvatarUrl, cancellationToken);

        var url = await fileStorage.SaveAvatarAsync(
            request.UserId, request.FileStream, request.FileName, cancellationToken);

        user.AvatarUrl = url;
        user.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return url;
    }
}
