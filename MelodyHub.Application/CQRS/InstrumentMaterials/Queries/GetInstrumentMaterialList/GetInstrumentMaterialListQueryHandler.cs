using MediatR;
using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.InstrumentMaterials.Queries.GetInstrumentMaterialList;

public class GetInstrumentMaterialListQueryHandler(IMelodyHubDbContext context)
    : IRequestHandler<GetInstrumentMaterialListQuery, InstrumentMaterialListVm>
{

    public async Task<InstrumentMaterialListVm> Handle(
        GetInstrumentMaterialListQuery request,
        CancellationToken cancellationToken)
    {
        var items = await context.InstrumentMaterials
            .AsNoTracking()
            .Include(im => im.Instrument)
            .Include(im => im.Material)
            .Select(im => new InstrumentMaterialListLookupDto
            {
                InstrumentId = im.InstrumentId,
                InstrumentName = im.Instrument.Name,
                MaterialId = im.MaterialId,
                MaterialName = im.Material.Name,
                Quantity = im.Quantity,
                Notes = im.Notes,
                MaterialUnitPrice = im.Material.AvgPrice,
                MaterialUnit = im.Material.Unit.ToString(),
                MaterialImageUrl = im.Material.ImageUrl
            })
            .OrderBy(dto => dto.InstrumentName)
            .ThenBy(dto => dto.MaterialName)
            .ToListAsync(cancellationToken);

        return new InstrumentMaterialListVm { Items = items };
    }
}
