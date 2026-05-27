using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.Instruments.Commands.CreateInstrument;

public class CreateInstrumentCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<CreateInstrumentCommand, Guid>
{
    public async Task<Guid> Handle(CreateInstrumentCommand request, CancellationToken cancellationToken)
    {
        var normalizedName = request.Name?.Trim();
        if (string.IsNullOrWhiteSpace(normalizedName))
            throw new BadRequestException("Название инструмента не может быть пустым");

        var exists = await context.Instruments
            .AnyAsync(i => i.Name.ToLower() == normalizedName.ToLower(), cancellationToken);

        if (exists)
            throw new BadRequestException("Инструмент с таким названием уже существует");

        var newInstrument = new Instrument
        {
            Id = Guid.NewGuid(),
            Name = normalizedName,
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
