using AutoMapper;
using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;

namespace MelodyHub.Application.CQRS.InstrumentCategories.Queries.GetInstrumentCategoryDetails;

public class GetInstrumentCategoryDetailsQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetInstrumentCategoryDetailsQuery, InstrumentCategoryDetailsVm>
{
    public async Task<InstrumentCategoryDetailsVm> Handle(GetInstrumentCategoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var instrumentCategory = await context.InstrumentCategories
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(InstrumentCategories), request.Id);

        return mapper.Map<InstrumentCategoryDetailsVm>(instrumentCategory);
    }
}
