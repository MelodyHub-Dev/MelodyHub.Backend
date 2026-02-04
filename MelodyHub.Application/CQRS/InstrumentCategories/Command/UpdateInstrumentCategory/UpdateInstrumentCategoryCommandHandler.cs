using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;

namespace MelodyHub.Application.CQRS.InstrumentCategories.Command.UpdateInstrumentCategory;

public class UpdateInstrumentCategoryCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<UpdateInstrumentCategoryCommand>
{
    public async Task Handle(UpdateInstrumentCategoryCommand request, CancellationToken cancellationToken)
    {
        var instrumentCategory = await context.InstrumentCategories
            .FindAsync([request.Id], cancellationToken) 
            ?? throw new NotFoundException(nameof(InstrumentCategories), request.Id);

        instrumentCategory.Name = request.Name;
        instrumentCategory.Description = request.Description;
        instrumentCategory.Slug = request.Slug;

        await context.SaveChangesAsync(cancellationToken);
    }
}
