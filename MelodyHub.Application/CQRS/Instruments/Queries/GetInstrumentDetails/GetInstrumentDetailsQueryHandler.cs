using AutoMapper;
using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Instruments.Queries.GetInstrumentDetails;

public class GetInstrumentDetailsQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetInstrumentDetailsQuery, InstrumentDetailVm>
{
    public async Task<InstrumentDetailVm> Handle(GetInstrumentDetailsQuery request, CancellationToken cancellationToken)
    {
        var instrument = await context.Instruments
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(Instrument), request.Id);

        return mapper.Map<InstrumentDetailVm>(instrument);
    }
}
