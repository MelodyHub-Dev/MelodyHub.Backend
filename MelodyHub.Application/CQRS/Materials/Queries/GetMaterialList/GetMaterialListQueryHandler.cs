using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.Materials.Queries.GetMaterialList;

public class GetMaterialListQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetMaterialListQuery, MaterialListVm>
{
    public async Task<MaterialListVm> Handle(GetMaterialListQuery request, CancellationToken cancellationToken)
    {
        var materials = await context.Materials
            .ProjectTo<MaterialListLookupDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new MaterialListVm { Materials = materials };
    }
}
