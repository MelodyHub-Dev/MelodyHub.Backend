using MediatR;

namespace MelodyHub.Application.CQRS.InstrumentCategories.Command.CreateInstrumentCategory;

public class CreateInstrumentCategoryCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
}
