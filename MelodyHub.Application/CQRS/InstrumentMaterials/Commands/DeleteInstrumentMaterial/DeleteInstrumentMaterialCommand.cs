using MediatR;

namespace MelodyHub.Application.CQRS.InstrumentMaterials.Commands.DeleteInstrumentMaterial;

public class DeleteInstrumentMaterialCommand : IRequest
{
    public Guid InstrumentId { get; set; }
    public Guid MaterialId { get; set; }
}
