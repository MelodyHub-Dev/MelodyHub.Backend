namespace MelodyHub.Application.CQRS.Materials.Queries.GetMaterialList;

public class MaterialListVm
{
    public IList<MaterialListLookupDto> Materials { get; set; } = [];
}
