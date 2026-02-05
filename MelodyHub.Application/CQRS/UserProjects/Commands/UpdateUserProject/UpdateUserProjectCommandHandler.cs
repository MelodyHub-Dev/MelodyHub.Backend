using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.UserProjects.Commands.UpdateUserProject;

public class UpdateUserProjectCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<UpdateUserProjectCommand>
{
    public async Task Handle(UpdateUserProjectCommand request, CancellationToken cancellationToken)
    {
        var userProject = await context.UserProjects
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(UserProject), request.Id);

        userProject.Name = request.Name;
        userProject.Description = request.Description;
        userProject.Status = request.Status;
        userProject.Progress = request.Progress;
        userProject.StartDate = request.StartDate;
        userProject.FinishDate = request.FinishDate;
        userProject.ActualCost = request.ActualCost;
        userProject.Notes = request.Notes;

        await context.SaveChangesAsync(cancellationToken);
    }
}
