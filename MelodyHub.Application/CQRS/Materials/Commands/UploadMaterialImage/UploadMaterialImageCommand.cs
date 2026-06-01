using MediatR;

namespace MelodyHub.Application.CQRS.Materials.Commands.UploadMaterialImage;

public class UploadMaterialImageCommand : IRequest<string>
{
    public Guid MaterialId { get; set; }
    public Stream FileStream { get; set; } = null!;
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
}