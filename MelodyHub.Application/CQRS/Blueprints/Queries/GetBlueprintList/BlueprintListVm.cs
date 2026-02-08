namespace MelodyHub.Application.CQRS.Blueprints.Queries.GetBlueprintList;

public class BlueprintListVm 
{
    public IList<BlueprintListLookupDto> Blueprints { get; set; } = [];
}
