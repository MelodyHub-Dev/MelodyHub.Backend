using MediatR;

namespace MelodyHub.Application.CQRS.Blueprints.Queries.GetBlueprintList;

public class GetBlueprintListQuery : IRequest<BlueprintListVm>
{
    public Guid? InstrumentId { get; set; }
}
