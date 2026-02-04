using MediatR;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Materials.Commands.CreateMaterial;

public class CreateMaterialCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<CreateMaterialCommand, Guid>
{
    public async Task<Guid> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
    {
        var newMaterial = new Material
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Unit = request.Unit,
            AvgPrice = request.AvgPrice,
            Category = request.Category,
            CreatedAt = DateTime.UtcNow
        };

        await context.Materials.AddAsync(newMaterial, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newMaterial.Id;
    }
}
