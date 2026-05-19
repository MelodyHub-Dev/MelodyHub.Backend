using MediatR;
using MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectDetails;

namespace MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectById;

public class GetUserProjectByIdQuery : IRequest<UserProjectDetailsVm>
{
    public Guid Id { get; set; }
}