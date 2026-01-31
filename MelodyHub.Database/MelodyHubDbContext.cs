using MelodyHub.Application.Interfaces;
using MelodyHub.Database.EntityTypeConfigurations;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Database;

public class MelodyHubDbContext(DbContextOptions<MelodyHubDbContext> options) 
    : DbContext(options), IMelodyHubDbContext
{
    public DbSet<User> Users { get; } = null!;
    public DbSet<UserProject> UserProjects { get; } = null!;
    public DbSet<UserFavorite> UserFavorites { get; } = null!;
    public DbSet<BlogArticle> BlogArticles { get; } = null!;
    public DbSet<ArticleComment> ArticleComments { get; } = null!;
    public DbSet<Instrument> Instruments { get; } = null!;
    public DbSet<InstrumentCategory> InstrumentCategories { get; } = null!;
    public DbSet<InstrumentMaterial> InstrumentMaterials { get; } = null!;
    public DbSet<Material> Materials { get; } = null!;
    public DbSet<Blueprint> Blueprints { get; } = null!;
    public DbSet<Quiz> Quizzes { get; } = null!;
    public DbSet<QuizQuestion> QuizQuestions { get; } = null!;
    public DbSet<QuizResult> QuizResults { get; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(MelodyHubDbContext).Assembly);
        base.OnModelCreating(builder);
    }
}
