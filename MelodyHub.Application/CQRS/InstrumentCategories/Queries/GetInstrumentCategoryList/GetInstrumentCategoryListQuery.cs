using MediatR;

namespace MelodyHub.Application.CQRS.InstrumentCategories.Queries.GetInstrumentCategoryList;

public class GetInstrumentCategoryListQuery : IRequest<InstrumentCategoryListVm>
{}
