using MediatR;

namespace MelodyHub.Application.CQRS.Instruments.Queries.GetInstrumentDetails;

public class GetInstrumentDetailsQuery : IRequest<InstrumentDetailVm>
{
    public Guid Id { get; set; }
}
