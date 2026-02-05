using MediatR;

namespace MelodyHub.Application.CQRS.InstrumentMaterials.Commands.UpdateInstrumentMaterial;

public class UpdateInstrumentMaterialCommand : IRequest
{
    public Guid InstrumentId { get; set; }
    public Guid MaterialId { get; set; }
    public decimal Quantity { get; set; } = 1.00m;
    public string? Notes { get; set; }
}
