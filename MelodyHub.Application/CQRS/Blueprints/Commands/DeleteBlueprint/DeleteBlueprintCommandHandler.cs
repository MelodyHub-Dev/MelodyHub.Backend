using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Blueprints.Commands.DeleteBlueprint;

public class DeleteBlueprintCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<DeleteBlueprintCommand>
{
    public async Task Handle(DeleteBlueprintCommand request, CancellationToken cancellationToken)
    {
        var blueprint = await context.Blueprints
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(Blueprint), request.Id);

        context.Blueprints.Remove(blueprint);
        await context.SaveChangesAsync(cancellationToken);
    }
}
