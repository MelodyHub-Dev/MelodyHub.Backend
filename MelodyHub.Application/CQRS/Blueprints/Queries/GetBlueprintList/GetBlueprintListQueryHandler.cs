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
        var query = context.Blueprints.AsQueryable();

        if (request.InstrumentId.HasValue)
        {
            query = query.Where(b => b.InstrumentId == request.InstrumentId.Value);
        }

        var blueprints = await query
            .ProjectTo<BlueprintListLookupDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new BlueprintListVm { Blueprints = blueprints };
    }
}