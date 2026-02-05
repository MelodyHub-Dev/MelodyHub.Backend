using MediatR;

namespace MelodyHub.Application.CQRS.UserProjects.Commands.DeleteUserProject;

public class DeleteUserProjectCommand : IRequest
{
    public Guid Id { get; set; }
}
