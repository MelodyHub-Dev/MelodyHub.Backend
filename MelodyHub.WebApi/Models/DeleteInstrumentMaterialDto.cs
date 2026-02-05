using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.InstrumentMaterials.Commands.DeleteInstrumentMaterial;

namespace MelodyHub.WebApi.Models;

public class DeleteInstrumentMaterialDto : IMapWith<DeleteInstrumentMaterialCommand>
{
    public Guid InstrumentId { get; set; }
    public Guid MaterialId { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<DeleteInstrumentMaterialDto, DeleteInstrumentMaterialCommand>();
}