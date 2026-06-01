using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Materials.Commands.UploadMaterialImage;

public class UploadMaterialImageCommandHandler(
    IMelodyHubDbContext context,
    IFileStorageService fileStorage)
    : IRequestHandler<UploadMaterialImageCommand, string>
{
    private static readonly string[] AllowedTypes = ["image/jpeg", "image/png", "image/webp", "image/gif"];
    private const long MaxBytes = 10 * 1024 * 1024; // 10 MB

    public async Task<string> Handle(UploadMaterialImageCommand request, CancellationToken cancellationToken)
    {
        if (!AllowedTypes.Contains(request.ContentType))
            throw new BadRequestException("Допустимые форматы: JPEG, PNG, WebP, GIF");

        if (request.FileStream.Length > MaxBytes)
            throw new BadRequestException("Размер файла не должен превышать 10 МБ");

        var material = await context.Materials.FindAsync([request.MaterialId], cancellationToken)
            ?? throw new NotFoundException(nameof(Material), request.MaterialId);

        await fileStorage.DeleteMaterialImageAsync(material.ImageUrl, cancellationToken);

        var url = await fileStorage.SaveMaterialImageAsync(
            request.MaterialId, request.FileStream, request.FileName, cancellationToken);

        material.ImageUrl = url;
        await context.SaveChangesAsync(cancellationToken);

        return url;
    }
}