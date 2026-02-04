using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.Instruments.Queries.GetInstrumentList;

public class GetInstrumentListQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetInstrumentListQuery, InstrumentListVm>
{
    public async Task<InstrumentListVm> Handle(GetInstrumentListQuery request, CancellationToken cancellationToken)
    {
        var instruments = await context.Instruments
            .ProjectTo<InstrumentListLookupDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new InstrumentListVm { Instruments = instruments };
    }
}
