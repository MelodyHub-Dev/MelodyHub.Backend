using MediatR;

namespace MelodyHub.Application.CQRS.Instruments.Queries.GetInstrumentList;

public class GetInstrumentListQuery : IRequest<InstrumentListVm>
{}
