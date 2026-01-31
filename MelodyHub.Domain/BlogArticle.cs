namespace MelodyHub.Domain;

public class BlogArticle
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Excerpt { get; set; }
    public int AuthorId { get; set; }
    public string? ImageUrl { get; set; }
    public int ViewsCount { get; set; }
    public bool IsPublished { get; set; } = true;
    public DateTime? PublishedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User Author { get; set; } = null!;
    public ICollection<ArticleComment> Comments { get; set; } = [];

    public bool IsNew => CreatedAt > DateTime.UtcNow.AddDays(-7);
    public int CommentCount => Comments.Count(c => c.IsApproved);
}
