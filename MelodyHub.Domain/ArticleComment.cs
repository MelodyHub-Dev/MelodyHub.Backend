namespace MelodyHub.Domain;

public class ArticleComment
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UserId { get; set; }
    public Guid? ParentCommentId { get; set; }
    public string Content { get; set; } = string.Empty;
    public bool IsApproved { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public BlogArticle Article { get; set; } = null!;
    public User User { get; set; } = null!;
    public ArticleComment? ParentComment { get; set; }
    public ICollection<ArticleComment> Replies { get; set; } = [];
}
