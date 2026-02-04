using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.InstrumentCategories.Command.UpdateInstrumentCategory;

namespace MelodyHub.WebApi.Models;

public class UpdateInstrumentCategoryDto : IMapWith<UpdateInstrumentCategoryCommand>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;

    public void Mapping(Profile profile)
        => profile.CreateMap<UpdateInstrumentCategoryDto, UpdateInstrumentCategoryCommand>();
}
