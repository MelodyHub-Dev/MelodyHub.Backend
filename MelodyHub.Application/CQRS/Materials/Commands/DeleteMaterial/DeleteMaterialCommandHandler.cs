using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Materials.Commands.DeleteMaterial;

public class DeleteMaterialCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<DeleteMaterialCommand>
{
    public async Task Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = await context.Materials
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(Material), request.Id);

        context.Materials.Remove(material);
        await context.SaveChangesAsync(cancellationToken);
    }
}
