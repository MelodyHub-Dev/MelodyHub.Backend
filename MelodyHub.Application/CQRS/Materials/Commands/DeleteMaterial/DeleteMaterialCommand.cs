using MediatR;

namespace MelodyHub.Application.CQRS.Materials.Commands.DeleteMaterial;

public class DeleteMaterialCommand : IRequest
{
    public Guid Id { get; set; }
}
