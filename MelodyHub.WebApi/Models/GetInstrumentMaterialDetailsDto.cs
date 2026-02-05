using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.InstrumentMaterials.Queries.GetInstrumentMaterialDetails;

namespace MelodyHub.WebApi.Models;

public class GetInstrumentMaterialDetailsDto : IMapWith<GetInstrumentMaterialDetailsQuery>
{
    public Guid InstrumentId { get; set; }
    public Guid MaterialId { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<GetInstrumentMaterialDetailsDto, GetInstrumentMaterialDetailsQuery>();
}