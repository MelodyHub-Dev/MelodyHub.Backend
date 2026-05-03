using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.UserProjects.Commands.CreateUserProject;

public class CreateUserProjectCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<CreateUserProjectCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserProjectCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .FindAsync([request.UserId], cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.UserId);

        var instrument = await context.Instruments
            .FindAsync([request.InstrumentId], cancellationToken)
            ?? throw new NotFoundException(nameof(Instrument), request.InstrumentId);

        var newUserProject = new UserProject
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            InstrumentId = instrument.Id,
            Name = request.Name,
            Description = request.Description,
            Status = request.Status,
            Progress = request.Progress,
            StartDate = request.StartDate,
            FinishDate = request.FinishDate,
            ActualCost = request.ActualCost,
            Notes = [],
        };

        await context.UserProjects.AddAsync(newUserProject, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newUserProject.Id;
    }
}
