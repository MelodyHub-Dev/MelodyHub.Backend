using MediatR;

namespace MelodyHub.Application.CQRS.InstrumentMaterials.Queries.GetInstrumentMaterialDetails;

public class GetInstrumentMaterialDetailsQuery : IRequest<InstrumentMaterialDetailsVm>
{
    public Guid InstrumentId { get; set; }
    public Guid MaterialId { get; set; }
}
