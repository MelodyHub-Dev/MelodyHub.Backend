using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.Instruments.Commands.UpdateInstrument;

public class UpdateInstrumentCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<UpdateInstrumentCommand>
{
    public async Task Handle(UpdateInstrumentCommand request, CancellationToken cancellationToken)
    {
        var instrument = await context.Instruments
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(Instrument), request.Id);

        instrument.Name = request.Name ?? instrument.Name;
        instrument.Description = request.Description ?? instrument.Description;
        instrument.ShortDescription = request.ShortDescription ?? instrument.ShortDescription;
        instrument.Difficulty = request.Difficulty;
        instrument.EstimatedHours = request.EstimatedHours ?? instrument.EstimatedHours;
        instrument.MainImageUrl = request.MainImageUrl ?? instrument.MainImageUrl;
        instrument.UpdatedAt = DateTime.UtcNow;

        if (request.CategoryId != instrument.CategoryId)
        {
            var categoryExists = await context.InstrumentCategories
                .AnyAsync(x => x.Id == request.CategoryId, cancellationToken);

            if (!categoryExists)
                throw new NotFoundException(nameof(InstrumentCategory), request.CategoryId);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}
