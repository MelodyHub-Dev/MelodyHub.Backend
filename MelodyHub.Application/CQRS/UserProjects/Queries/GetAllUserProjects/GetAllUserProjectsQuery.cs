using MediatR;
using MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectList;

namespace MelodyHub.Application.CQRS.UserProjects.Queries.GetAllUserProjects;

public class GetAllUserProjectsQuery : IRequest<UserProjectListVm>
{
}