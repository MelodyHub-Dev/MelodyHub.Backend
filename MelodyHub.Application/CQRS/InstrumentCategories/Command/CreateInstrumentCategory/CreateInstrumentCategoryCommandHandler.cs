using MediatR;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.InstrumentCategories.Command.CreateInstrumentCategory;

public class CreateInstrumentCategoryCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<CreateInstrumentCategoryCommand, Guid>
{
    public async Task<Guid> Handle(CreateInstrumentCategoryCommand request, CancellationToken cancellationToken)
    {
        var newInstrumentCategory = new InstrumentCategory
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Slug = request.Slug,
        };

        await context.InstrumentCategories.AddAsync(newInstrumentCategory, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newInstrumentCategory.Id;
    }
}
