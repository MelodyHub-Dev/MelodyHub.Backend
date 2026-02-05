using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.InstrumentMaterials.Commands.DeleteInstrumentMaterial;

public class DeleteInstrumentMaterialCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<DeleteInstrumentMaterialCommand>
{
    public async Task Handle(DeleteInstrumentMaterialCommand request, CancellationToken cancellationToken)
    {
        var instrumentMaterial = await context.InstrumentMaterials
            .FirstOrDefaultAsync(x => x.InstrumentId == request.InstrumentId && x.MaterialId == request.MaterialId, 
            cancellationToken) 
            ?? throw new NotFoundException(nameof(InstrumentMaterial), $"{request.InstrumentId}, {request.MaterialId}");

        context.InstrumentMaterials.Remove(instrumentMaterial);
        await context.SaveChangesAsync(cancellationToken);
    }
}
