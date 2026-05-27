using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Blueprints.Commands.UploadBlueprintImage;

public class UploadBlueprintImageCommandHandler(
    IMelodyHubDbContext context,
    IFileStorageService fileStorage)
    : IRequestHandler<UploadBlueprintImageCommand, string>
{
    private static readonly string[] AllowedTypes = ["image/jpeg", "image/png", "image/webp", "image/gif"];
    private const long MaxBytes = 10 * 1024 * 1024; // 10 MB

    public async Task<string> Handle(UploadBlueprintImageCommand request, CancellationToken cancellationToken)
    {
        if (!AllowedTypes.Contains(request.ContentType))
            throw new BadRequestException("Допустимые форматы: JPEG, PNG, WebP, GIF");

        if (request.FileStream.Length > MaxBytes)
            throw new BadRequestException("Размер файла не должен превышать 10 МБ");

        var blueprint = await context.Blueprints.FindAsync([request.BlueprintId], cancellationToken)
            ?? throw new NotFoundException(nameof(Blueprint), request.BlueprintId);

        await fileStorage.DeleteBlueprintImageAsync(blueprint.ImageUrl, cancellationToken);

        var url = await fileStorage.SaveBlueprintImageAsync(
            request.BlueprintId, request.FileStream, request.FileName, cancellationToken);

        blueprint.ImageUrl = url;

        await context.SaveChangesAsync(cancellationToken);

        return url;
    }
}
