using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectList;

public class GetUserProjectListQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetUserProjectListQuery, UserProjectListVm>
{
    public async Task<UserProjectListVm> Handle(GetUserProjectListQuery request, CancellationToken cancellationToken)
    {
        var userProjects = await context.UserProjects
            .Where(x => x.UserId == request.UserId)
            .ProjectTo<UserProjectListLookupDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new UserProjectListVm { UserProjects = userProjects };
    }
}
