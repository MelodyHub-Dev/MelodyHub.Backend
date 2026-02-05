using AutoMapper;
using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectDetails;

public class GetUserProjectDetailsQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetUserProjectDetailsQuery, UserProjectDetailsVm>
{
    public async Task<UserProjectDetailsVm> Handle(GetUserProjectDetailsQuery request, CancellationToken cancellationToken)
    {
        var userProject = await context.UserProjects
            .FindAsync([request.UserProjectId], cancellationToken)
            ?? throw new NotFoundException(nameof(UserProject), request.UserProjectId);

        if (userProject.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(UserProject), request.UserProjectId);
        }

        return mapper.Map<UserProjectDetailsVm>(userProject);
    }
}
