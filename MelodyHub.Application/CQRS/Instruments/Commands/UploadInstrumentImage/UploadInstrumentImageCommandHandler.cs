using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Instruments.Commands.UploadInstrumentImage;

public class UploadInstrumentImageCommandHandler(
    IMelodyHubDbContext context,
    IFileStorageService fileStorage)
    : IRequestHandler<UploadInstrumentImageCommand, string>
{
    private static readonly string[] AllowedTypes = ["image/jpeg", "image/png", "image/webp", "image/gif"];
    private const long MaxBytes = 10 * 1024 * 1024; // 10 MB

    public async Task<string> Handle(UploadInstrumentImageCommand request, CancellationToken cancellationToken)
    {
        if (!AllowedTypes.Contains(request.ContentType))
            throw new BadRequestException("Допустимые форматы: JPEG, PNG, WebP, GIF");

        if (request.FileStream.Length > MaxBytes)
            throw new BadRequestException("Размер файла не должен превышать 10 МБ");

        var instrument = await context.Instruments.FindAsync([request.InstrumentId], cancellationToken)
            ?? throw new NotFoundException(nameof(Instrument), request.InstrumentId);

        // Удаляем старое изображение если есть
        await fileStorage.DeleteInstrumentImageAsync(instrument.MainImageUrl, cancellationToken);

        var url = await fileStorage.SaveInstrumentImageAsync(
            request.InstrumentId, request.FileStream, request.FileName, cancellationToken);

        instrument.MainImageUrl = url;
        instrument.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return url;
    }
}