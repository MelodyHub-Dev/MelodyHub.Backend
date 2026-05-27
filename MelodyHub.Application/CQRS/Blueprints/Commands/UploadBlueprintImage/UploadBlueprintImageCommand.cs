using MediatR;

namespace MelodyHub.Application.CQRS.Blueprints.Commands.UploadBlueprintImage;

public class UploadBlueprintImageCommand : IRequest<string>
{
    public Guid BlueprintId { get; set; }
    public Stream FileStream { get; set; } = null!;
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
}
