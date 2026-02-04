namespace MelodyHub.Application.CQRS.InstrumentCategories.Queries.GetInstrumentCategoryList;

public class InstrumentCategoryListVm
{
    public IList<InstrumentCategoryListLookupDto> InstrumentCategories { get; set; } = [];
}
