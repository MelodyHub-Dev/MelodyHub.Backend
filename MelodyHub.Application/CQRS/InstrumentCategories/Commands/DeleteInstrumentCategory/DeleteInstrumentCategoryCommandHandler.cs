using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;

namespace MelodyHub.Application.CQRS.InstrumentCategories.Command.DeleteInstrumentCategory;

public class DeleteInstrumentCategoryCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<DeleteInstrumentCategoryCommand>
{
    public async Task Handle(DeleteInstrumentCategoryCommand request, CancellationToken cancellationToken)
    {
        var instrumentCategory = await context.InstrumentCategories
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(InstrumentCategories), request.Id);

        context.InstrumentCategories.Remove(instrumentCategory);
        await context.SaveChangesAsync(cancellationToken);
    }
}
