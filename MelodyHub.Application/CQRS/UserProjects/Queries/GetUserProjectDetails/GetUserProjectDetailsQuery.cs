using MediatR;

namespace MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectDetails;

public class GetUserProjectDetailsQuery : IRequest<UserProjectDetailsVm>
{
    public Guid UserProjectId { get; set; }
    public Guid UserId { get; set; }
}
