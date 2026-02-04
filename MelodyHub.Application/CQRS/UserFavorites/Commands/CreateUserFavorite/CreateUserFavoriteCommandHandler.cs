using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.UserFavorites.Commands.CreateUserFavorite;

public class CreateUserFavoriteCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<CreateUserFavoriteCommand>
{
    public async Task Handle(CreateUserFavoriteCommand request, CancellationToken cancellationToken)
    {
        var exists = await context.UserFavorites
            .AnyAsync(x => x.UserId == request.UserId && x.InstrumentId == request.InstrumentId, 
            cancellationToken);

        if (exists)
        {
            throw new ConflictException("This instrument is already in favorites");
        }

        var user = await context.Users
            .FindAsync([request.UserId], cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.UserId);

        var instrument = await context.Instruments
            .FindAsync([request.InstrumentId], cancellationToken)
            ?? throw new NotFoundException(nameof(Instrument), request.InstrumentId);

        var newUserFavorite = new UserFavorite
        {
            UserId = user.Id,
            User = user,
            InstrumentId = instrument.Id,
            Instrument = instrument,
            CreatedAt = DateTime.UtcNow
        };

        await context.UserFavorites.AddAsync(newUserFavorite, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
