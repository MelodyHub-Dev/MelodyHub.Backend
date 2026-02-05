using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.InstrumentMaterials.Commands.UpdateInstrumentMaterial;

namespace MelodyHub.WebApi.Models;

public class UpdateInstrumentMaterialDto : IMapWith<UpdateInstrumentMaterialCommand>
{
    public Guid InstrumentId { get; set; }
    public Guid MaterialId { get; set; }
    public decimal Quantity { get; set; } = 1.00m;
    public string? Notes { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<UpdateInstrumentMaterialDto, UpdateInstrumentMaterialCommand>();
}
