using MediatR;

namespace MelodyHub.Application.CQRS.Auth;

public class SendVerificationEmailCommand : IRequest
{
    public Guid UserId { get; set; }
}
