using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.InstrumentMaterials.Commands.UpdateInstrumentMaterial;

public class UpdateInstrumentMaterialCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<UpdateInstrumentMaterialCommand>
{
    public async Task Handle(UpdateInstrumentMaterialCommand request, CancellationToken cancellationToken)
    {
        var instrumentMaterial = await context.InstrumentMaterials
            .FirstOrDefaultAsync(x => x.InstrumentId == request.InstrumentId && x.MaterialId == request.MaterialId,
            cancellationToken)
            ?? throw new NotFoundException(nameof(InstrumentMaterial), $"{request.InstrumentId}, {request.MaterialId}");

        instrumentMaterial.Quantity = request.Quantity;
        instrumentMaterial.Notes = request.Notes;

        await context.SaveChangesAsync(cancellationToken);
    }
}
