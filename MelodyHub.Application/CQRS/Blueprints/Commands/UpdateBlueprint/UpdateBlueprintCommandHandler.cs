using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Blueprints.Commands.UpdateBlueprint;

public class UpdateBlueprintCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<UpdateBlueprintCommand>
{
    public async Task Handle(UpdateBlueprintCommand request, CancellationToken cancellationToken)
    {
        var blueprint = await context.Blueprints
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(Blueprint), request.Id);

        blueprint.Title = request.Title;
        blueprint.StepNumber = request.StepNumber;
        blueprint.Content = request.Content;
        blueprint.ImageUrl = request.ImageUrl;
        blueprint.VideoUrl = request.VideoUrl;
        blueprint.EstimatedTimeMinutes = request.EstimatedTimeMinutes;

        await context.SaveChangesAsync(cancellationToken);
    }
}
