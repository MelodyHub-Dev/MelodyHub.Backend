using MediatR;

namespace MelodyHub.Application.CQRS.InstrumentCategories.Queries.GetInstrumentCategoryDetails;

public class GetInstrumentCategoryDetailsQuery : IRequest<InstrumentCategoryDetailsVm>
{
    public Guid Id { get; set; }
}
