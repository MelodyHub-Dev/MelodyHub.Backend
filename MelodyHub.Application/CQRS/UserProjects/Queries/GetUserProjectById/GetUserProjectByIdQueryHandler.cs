using AutoMapper;
using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectDetails;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectById;

public class GetUserProjectByIdQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetUserProjectByIdQuery, UserProjectDetailsVm>
{
    public async Task<UserProjectDetailsVm> Handle(GetUserProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var userProject = await context.UserProjects
            .Include(x => x.User)
            .Include(x => x.Instrument)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(UserProject), request.Id);

        var vm = mapper.Map<UserProjectDetailsVm>(userProject);
        vm.AuthorName = userProject.User.Username;
        vm.InstrumentName = userProject.Instrument.Name;

        return vm;
    }
}