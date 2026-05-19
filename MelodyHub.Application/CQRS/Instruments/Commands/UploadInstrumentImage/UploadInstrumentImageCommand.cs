using MediatR;

namespace MelodyHub.Application.CQRS.Instruments.Commands.UploadInstrumentImage;

public class UploadInstrumentImageCommand : IRequest<string>
{
    public Guid InstrumentId { get; set; }
    public Stream FileStream { get; set; } = null!;
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
}