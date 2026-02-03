using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.Users.Queries.GetUserList;

public class GetUserListQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetUserListQuery, UserListVm>
{
    public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        if (!context.Users.Any())
        {
            return new UserListVm { Users = [] };
        }

        var users = await context.Users
            .ProjectTo<UserListLookupDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new UserListVm { Users = users };
    }
}
