using AutoMapper;
using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Blueprints.Queries.GetBlueprintDetails;

public class GetBlueprintDetailsQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetBlueprintDetailsQuery, BlueprintDetailsVm>
{
    public async Task<BlueprintDetailsVm> Handle(GetBlueprintDetailsQuery request, CancellationToken cancellationToken)
    {
        var blueprint = await context.Blueprints
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(Blueprint), request.Id);

        return mapper.Map<BlueprintDetailsVm>(blueprint);
    }
}
