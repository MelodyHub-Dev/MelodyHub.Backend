using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.InstrumentCategories.Queries.GetInstrumentCategoryList;

public class InstrumentCategoryListLookupDto : IMapWith<InstrumentCategory>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;

    public void Mapping(Profile profile)
        => profile.CreateMap<InstrumentCategory,  InstrumentCategoryListLookupDto>();
}
