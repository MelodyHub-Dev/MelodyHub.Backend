using AutoMapper;
using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Materials.Queries.GetMaterialDetails;

public class GetMaterialDetailsQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetMaterialDetailsQuery, MaterialDetailsVm>
{
    public async Task<MaterialDetailsVm> Handle(GetMaterialDetailsQuery request, CancellationToken cancellationToken)
    {
        var material = await context.Materials
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(Material), request.Id);

        return mapper.Map<MaterialDetailsVm>(material);
    }
}
