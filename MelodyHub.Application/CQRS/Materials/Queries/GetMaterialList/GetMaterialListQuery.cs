using MediatR;

namespace MelodyHub.Application.CQRS.Materials.Queries.GetMaterialList;

public class GetMaterialListQuery : IRequest<MaterialListVm>
{}
