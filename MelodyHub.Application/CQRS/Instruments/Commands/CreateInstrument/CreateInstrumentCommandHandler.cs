using MediatR;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Instruments.Commands.CreateInstrument;

public class CreateInstrumentCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<CreateInstrumentCommand, Guid>
{
    public async Task<Guid> Handle(CreateInstrumentCommand request, CancellationToken cancellationToken)
    {
        var newInstrument = new Instrument
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            ShortDescription = request.ShortDescription,
            Difficulty = request.Difficulty,
            EstimatedHours = request.EstimatedHours,
            MainImageUrl = request.MainImageUrl,
            ViewsCount = request.ViewsCount,
            CategoryId = request.CategoryId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };

        await context.Instruments.AddAsync(newInstrument, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newInstrument.Id;
    }
}
