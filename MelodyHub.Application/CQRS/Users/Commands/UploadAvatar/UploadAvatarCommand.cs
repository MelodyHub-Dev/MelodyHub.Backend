using MediatR;

namespace MelodyHub.Application.CQRS.Users.Commands.UploadAvatar;

public class UploadAvatarCommand : IRequest<string>
{
    public Guid UserId { get; set; }
    /// <summary>Содержимое файла</summary>
    public Stream FileStream { get; set; } = Stream.Null;
    /// <summary>Оригинальное имя файла (нужно для расширения)</summary>
    public string FileName { get; set; } = string.Empty;
    /// <summary>MIME-тип</summary>
    public string ContentType { get; set; } = string.Empty;
}
