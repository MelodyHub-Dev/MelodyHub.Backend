using MediatR;

namespace MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectList;

public class GetUserProjectListQuery : IRequest<UserProjectListVm>
{
    public Guid UserId { get; set; }
}
