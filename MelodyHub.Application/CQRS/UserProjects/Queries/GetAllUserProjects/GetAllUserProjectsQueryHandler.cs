using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectList;
using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.UserProjects.Queries.GetAllUserProjects;

public class GetAllUserProjectsQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetAllUserProjectsQuery, UserProjectListVm>
{
    public async Task<UserProjectListVm> Handle(GetAllUserProjectsQuery request, CancellationToken cancellationToken)
    {
        var userProjects = await context.UserProjects
            .Include(x => x.User)
            .Include(x => x.Instrument)
            .Select(x => new UserProjectListLookupDto
            {
                Id = x.Id,
                InstrumentId = x.InstrumentId,
                InstrumentName = x.Instrument.Name,
                AuthorId = x.UserId,
                AuthorName = x.User.Username,
                Name = x.Name,
                Description = x.Description,
                Status = x.Status,
                Progress = x.Progress,
                StartDate = x.StartDate,
                FinishDate = x.FinishDate,
                ActualCost = x.ActualCost,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            })
            .ToListAsync(cancellationToken);

        return new UserProjectListVm { UserProjects = userProjects };
    }
}