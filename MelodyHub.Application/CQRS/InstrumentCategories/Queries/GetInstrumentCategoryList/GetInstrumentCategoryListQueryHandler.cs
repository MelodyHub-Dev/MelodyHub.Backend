using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.InstrumentCategories.Queries.GetInstrumentCategoryList;

public class GetInstrumentCategoryListQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetInstrumentCategoryListQuery, InstrumentCategoryListVm>
{
    public async Task<InstrumentCategoryListVm> Handle(GetInstrumentCategoryListQuery request, CancellationToken cancellationToken)
    {
        var instrumentCategoryList = await context.InstrumentCategories
            .ProjectTo<InstrumentCategoryListLookupDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new InstrumentCategoryListVm { InstrumentCategories = instrumentCategoryList };
    }
}