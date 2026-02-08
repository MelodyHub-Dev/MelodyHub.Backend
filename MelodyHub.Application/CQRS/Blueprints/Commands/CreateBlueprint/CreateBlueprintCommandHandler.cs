using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Blueprints.Commands.CreateBlueprint;

public class CreateBlueprintCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<CreateBlueprintCommand, Guid>
{
    public async Task<Guid> Handle(CreateBlueprintCommand request, CancellationToken cancellationToken)
    {
        var instrument = await context.Instruments
            .FindAsync([request.InstrumentId], cancellationToken)
            ?? throw new NotFoundException(nameof(Instrument), request.InstrumentId);

        var newBlueprint = new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = request.InstrumentId,
            Title = request.Title,
            StepNumber = request.StepNumber,
            Content = request.Content,
            ImageUrl = request.ImageUrl,
            VideoUrl = request.VideoUrl,
            EstimatedTimeMinutes = request.EstimatedTimeMinutes,
        };

        await context.Blueprints.AddAsync(newBlueprint, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newBlueprint.Id;
    }
}