using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.UserFavorites.Commands.DeleteUserFavorite;

public class DeleteUserFavoriteCommandHandler(IMelodyHubDbContext context) 
    : IRequestHandler<DeleteUserFavoriteCommand>
{
    public async Task Handle(DeleteUserFavoriteCommand request, CancellationToken cancellationToken)
    {
        var userFavorite = await context.UserFavorites
            .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.InstrumentId == request.InstrumentId, cancellationToken)
            ?? throw new NotFoundException(nameof(UserFavorite), $"{request.UserId}, {request.InstrumentId}");

        context.UserFavorites.Remove(userFavorite);

        await context.SaveChangesAsync(cancellationToken);
    }
}
