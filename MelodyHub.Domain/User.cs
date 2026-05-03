using MelodyHub.Domain.Enums;

namespace MelodyHub.Domain;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.User;
    public bool IsVerifiedEmail { get; set; }
    public string? EmailVerificationToken { get; set; }
    public DateTime? EmailVerificationTokenExpiresAt { get; set; }
    public string? AvatarUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    public ICollection<UserProject> Projects { get; set; } = [];
    public ICollection<UserFavorite> Favorites { get; set; } = [];
    public ICollection<BlogArticle> AuthoredArticles { get; set; } = [];
    public ICollection<ArticleComment> Comments { get; set; } = [];
    public ICollection<QuizResult> QuizResults { get; set; } = [];
}
