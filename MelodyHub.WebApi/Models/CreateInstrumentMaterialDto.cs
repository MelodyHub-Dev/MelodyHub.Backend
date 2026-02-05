using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.InstrumentMaterials.Commands.CreateInstrumentMaterial;

namespace MelodyHub.WebApi.Models;

public class CreateInstrumentMaterialDto : IMapWith<CreateInstrumentMaterialCommand>
{
    public Guid InstrumentId { get; set; }
    public Guid MaterialId { get; set; }
    public decimal Quantity { get; set; } = 1.00m;
    public string? Notes { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<CreateInstrumentMaterialDto, CreateInstrumentMaterialCommand>();
}
