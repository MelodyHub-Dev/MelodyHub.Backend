using MediatR;

namespace MelodyHub.Application.CQRS.Blueprints.Commands.UploadBlueprintVideo;

public class UploadBlueprintVideoCommand : IRequest<string>
{
    public Guid BlueprintId { get; set; }
    public Stream FileStream { get; set; } = null!;
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
}
