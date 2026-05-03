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
        var query = context.UserProjects.AsQueryable();

        if (request.UserId.HasValue)
        {
            query = query.Where(x => x.UserId == request.UserId.Value);
        }

        if (request.InstrumentId.HasValue)
        {
            query = query.Where(x => x.InstrumentId == request.InstrumentId.Value);
        }

        var userProjects = await query
            .ProjectTo<UserProjectListLookupDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new UserProjectListVm { UserProjects = userProjects };
    }
}
