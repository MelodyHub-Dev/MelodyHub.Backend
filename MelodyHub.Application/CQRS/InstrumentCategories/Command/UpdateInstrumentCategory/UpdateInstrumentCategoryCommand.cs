using MediatR;

namespace MelodyHub.Application.CQRS.InstrumentCategories.Command.UpdateInstrumentCategory;

public class UpdateInstrumentCategoryCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
}
