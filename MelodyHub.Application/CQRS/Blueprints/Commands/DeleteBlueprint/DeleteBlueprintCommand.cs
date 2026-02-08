using MediatR;

namespace MelodyHub.Application.CQRS.Blueprints.Commands.DeleteBlueprint;

public class DeleteBlueprintCommand : IRequest
{
    public Guid Id { get; set; }
}
