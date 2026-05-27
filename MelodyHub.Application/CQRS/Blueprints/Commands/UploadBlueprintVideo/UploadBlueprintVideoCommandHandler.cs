using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Blueprints.Commands.UploadBlueprintVideo;

public class UploadBlueprintVideoCommandHandler(
    IMelodyHubDbContext context,
    IFileStorageService fileStorage)
    : IRequestHandler<UploadBlueprintVideoCommand, string>
{
    private static readonly string[] AllowedTypes = ["video/mp4", "video/webm", "video/ogg"];
    private const long MaxBytes = 100 * 1024 * 1024; // 100 MB

    public async Task<string> Handle(UploadBlueprintVideoCommand request, CancellationToken cancellationToken)
    {
        if (!AllowedTypes.Contains(request.ContentType))
            throw new BadRequestException("Допустимые форматы видео: MP4, WEBM, OGG");

        if (request.FileStream.Length > MaxBytes)
            throw new BadRequestException("Размер файла не должен превышать 100 МБ");

        var blueprint = await context.Blueprints.FindAsync([request.BlueprintId], cancellationToken)
            ?? throw new NotFoundException(nameof(Blueprint), request.BlueprintId);

        await fileStorage.DeleteBlueprintVideoAsync(blueprint.VideoUrl, cancellationToken);

        var url = await fileStorage.SaveBlueprintVideoAsync(
            request.BlueprintId, request.FileStream, request.FileName, cancellationToken);

        blueprint.VideoUrl = url;

        await context.SaveChangesAsync(cancellationToken);

        return url;
    }
}
