namespace MelodyHub.Domain;

public class ProjectNote
{
    public Guid Id { get; set; }
    public Guid UserProjectId { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    public UserProject UserProject { get; set; } = null!;
}
