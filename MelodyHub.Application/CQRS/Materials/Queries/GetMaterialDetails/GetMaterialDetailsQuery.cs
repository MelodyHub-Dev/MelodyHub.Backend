using MediatR;

namespace MelodyHub.Application.CQRS.Materials.Queries.GetMaterialDetails;

public class GetMaterialDetailsQuery : IRequest<MaterialDetailsVm>
{
    public Guid Id { get; set; }
}
