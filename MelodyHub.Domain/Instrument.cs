using MelodyHub.Domain.Enums;

namespace MelodyHub.Domain;

public class Instrument
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ShortDescription { get; set; }
    public Guid CategoryId { get; set; }
    public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Intermediate;
    public int? EstimatedHours { get; set; }
    public string? MainImageUrl { get; set; }
    public int ViewsCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public InstrumentCategory Category { get; set; } = null!;
    public ICollection<Blueprint> Blueprints { get; set; } = [];
    public ICollection<UserProject> UserProjects { get; set; } = [];
    public ICollection<UserFavorite> FavoritedBy { get; set; } = [];
    public ICollection<InstrumentMaterial> InstrumentMaterials { get; set; } = [];
}
