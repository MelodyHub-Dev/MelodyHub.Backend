using FluentValidation;
using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.UserFavorites.Queries.GetUserFavoriteList;

public class GetUserFavoriteListQueryHandler(IMelodyHubDbContext context)
    : IRequestHandler<GetUserFavoriteListQuery, UserFavoritesListVm>
{
    public async Task<UserFavoritesListVm> Handle(GetUserFavoriteListQuery request, CancellationToken cancellationToken)
    {
        var isUserExist = await context.Users
            .AnyAsync(x => x.Id == request.UserId, cancellationToken);

        if (!isUserExist)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        var userFavorites = await context.UserFavorites
            .Where(x => x.UserId == request.UserId)
            .Select(x => x.InstrumentId)
            .ToListAsync(cancellationToken);

        return new UserFavoritesListVm { UserFavorites = userFavorites };
    }
}
