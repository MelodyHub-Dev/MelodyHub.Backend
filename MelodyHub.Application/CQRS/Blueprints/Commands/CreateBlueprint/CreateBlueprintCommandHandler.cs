using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.Blueprints.Commands.CreateBlueprint;

public class CreateBlueprintCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<CreateBlueprintCommand, Guid>
{
    public async Task<Guid> Handle(CreateBlueprintCommand request, CancellationToken cancellationToken)
    {
        // Проверяем, не существует ли уже шаг с таким номером для этого инструмента
        var exists = await context.Blueprints
            .AnyAsync(b => b.InstrumentId == request.InstrumentId && b.StepNumber == request.StepNumber, cancellationToken);

        if (exists)
            throw new BadRequestException("Шаг с таким номером уже существует");

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