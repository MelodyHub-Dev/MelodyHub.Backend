using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.Blueprints.Commands.UpdateBlueprint;

public class UpdateBlueprintCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<UpdateBlueprintCommand>
{
    public async Task Handle(UpdateBlueprintCommand request, CancellationToken cancellationToken)
    {
        var blueprint = await context.Blueprints
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(Blueprint), request.Id);

        // Проверяем, не конфликтует ли новый номер шага с другим шагом того же инструмента
        var conflict = await context.Blueprints
            .AnyAsync(b => b.InstrumentId == blueprint.InstrumentId && b.StepNumber == request.StepNumber && b.Id != request.Id, cancellationToken);

        if (conflict)
            throw new BadRequestException("Другой шаг с таким номером уже существует");

        blueprint.Title = request.Title;
        blueprint.StepNumber = request.StepNumber;
        blueprint.Content = request.Content;
        blueprint.ImageUrl = request.ImageUrl;
        blueprint.VideoUrl = request.VideoUrl;
        blueprint.EstimatedTimeMinutes = request.EstimatedTimeMinutes;

        await context.SaveChangesAsync(cancellationToken);
    }
}
