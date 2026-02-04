using MediatR;

namespace MelodyHub.Application.CQRS.Instruments.Commands.DeleteInstrument;

public class DeleteInstrumentCommand : IRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
}