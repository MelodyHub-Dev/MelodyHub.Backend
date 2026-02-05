using AutoMapper;
using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.InstrumentMaterials.Queries.GetInstrumentMaterialDetails;

public class GetInstrumentMaterialDetailsQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetInstrumentMaterialDetailsQuery, InstrumentMaterialDetailsVm>
{
    public async Task<InstrumentMaterialDetailsVm> Handle(
        GetInstrumentMaterialDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var instrumentMaterial = await context.InstrumentMaterials
            .FirstOrDefaultAsync(
                im => im.InstrumentId == request.InstrumentId &&
                      im.MaterialId == request.MaterialId,
                cancellationToken)
            ?? throw new NotFoundException(
                nameof(InstrumentMaterial),
                $"Link between instrument {request.InstrumentId} and material {request.MaterialId}");

        return mapper.Map<InstrumentMaterialDetailsVm>(instrumentMaterial);
    }
}
