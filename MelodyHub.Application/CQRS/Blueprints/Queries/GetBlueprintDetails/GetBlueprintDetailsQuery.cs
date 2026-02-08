using MediatR;

namespace MelodyHub.Application.CQRS.Blueprints.Queries.GetBlueprintDetails;

public class GetBlueprintDetailsQuery : IRequest<BlueprintDetailsVm>
{
    public Guid Id { get; set; }
}