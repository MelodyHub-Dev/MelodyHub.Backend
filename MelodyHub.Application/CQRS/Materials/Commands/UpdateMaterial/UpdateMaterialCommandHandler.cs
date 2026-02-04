using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Materials.Commands.UpdateMaterial;

public class UpdateMaterialCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<UpdateMaterialCommand>
{
    public async Task Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = await context.Materials
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(Material), request.Id);

        material.Name = request.Name;
        material.Description = request.Description;
        material.Unit = request.Unit;
        material.AvgPrice = request.AvgPrice;
        material.Category = request.Category;
        
        await context.SaveChangesAsync(cancellationToken);
    }
}
