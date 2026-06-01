using MediatR;
using MelodyHub.Domain.Enums;

namespace MelodyHub.Application.CQRS.Materials.Commands.CreateMaterial;

public class CreateMaterialCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public MaterialUnit Unit { get; set; } = MaterialUnit.Piece;
    public decimal AvgPrice { get; set; }
    public string? Category { get; set; }
    public string? ImageUrl { get; set; }
}
