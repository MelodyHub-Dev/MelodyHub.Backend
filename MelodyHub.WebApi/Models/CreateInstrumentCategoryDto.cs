using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.InstrumentCategories.Command.CreateInstrumentCategory;

namespace MelodyHub.WebApi.Models;

public class CreateInstrumentCategoryDto : IMapWith<CreateInstrumentCategoryCommand>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;

    public void Mapping(Profile profile)
        => profile.CreateMap<CreateInstrumentCategoryDto, CreateInstrumentCategoryCommand>();
}
