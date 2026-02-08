using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.Blueprints.Queries.GetBlueprintList;

public class GetBlueprintListQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetBlueprintListQuery, BlueprintListVm>
{
    public async Task<BlueprintListVm> Handle(GetBlueprintListQuery request, CancellationToken cancellationToken)
    {
        var blueprints = await context.Blueprints
            .ProjectTo<BlueprintListLookupDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new BlueprintListVm { Blueprints = blueprints };
    }
}