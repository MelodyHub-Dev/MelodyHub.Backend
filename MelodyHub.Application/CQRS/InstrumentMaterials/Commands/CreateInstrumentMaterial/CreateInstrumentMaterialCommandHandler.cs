using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.InstrumentMaterials.Commands.CreateInstrumentMaterial;

public class CreateInstrumentMaterialCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<CreateInstrumentMaterialCommand>
{
    public async Task Handle(CreateInstrumentMaterialCommand request, CancellationToken cancellationToken)
    {
        var newInstrumentMaterial = new InstrumentMaterial
        {
            MaterialId = request.MaterialId,
            InstrumentId = request.InstrumentId,
            Quantity = request.Quantity,
            Notes = request.Notes,
        };

        await context.InstrumentMaterials.AddAsync(newInstrumentMaterial, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
