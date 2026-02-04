namespace MelodyHub.Application.CQRS.Instruments.Queries.GetInstrumentList;

public class InstrumentListVm
{
    public IList<InstrumentListLookupDto> Instruments { get; set; } = [];
}
