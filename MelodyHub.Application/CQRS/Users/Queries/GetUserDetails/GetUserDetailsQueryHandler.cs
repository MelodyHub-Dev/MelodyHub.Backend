using AutoMapper;
using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Users.Queries.GetUserDetails;

public class GetUserDetailsQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
{
    public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.Id);

        return mapper.Map<UserDetailsVm>(user);
    }
}
