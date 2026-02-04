using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Instruments.Commands.DeleteInstrument;

public class DeleteInstrumentCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<DeleteInstrumentCommand>
{
    public async Task Handle(DeleteInstrumentCommand request, CancellationToken cancellationToken)
    {
        var instrument = await context.Instruments
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(Instrument), request.Id);
    
        context.Instruments.Remove(instrument);
        await context.SaveChangesAsync(cancellationToken);
    }
}
