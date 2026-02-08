using MediatR;

namespace MelodyHub.Application.CQRS.InstrumentCategories.Command.DeleteInstrumentCategory;

public class DeleteInstrumentCategoryCommand : IRequest
{
    public Guid Id { get; set; }
}
