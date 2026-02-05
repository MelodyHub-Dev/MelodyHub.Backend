using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.InstrumentMaterials.Queries.GetInstrumentMaterialDetails;

public class InstrumentMaterialDetailsVm : IMapWith<InstrumentMaterial>
{
    public Guid MaterialId { get; set; }
    public Guid InstrumentId { get; set; }
    public decimal Quantity { get; set; }
    public string? Notes { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<InstrumentMaterial, InstrumentMaterialDetailsVm>();
}
