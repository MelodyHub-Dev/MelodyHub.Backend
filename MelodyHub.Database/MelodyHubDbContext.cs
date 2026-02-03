using MelodyHub.Application.Interfaces;
using MelodyHub.Database.EntityTypeConfigurations;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MelodyHub.Database;

public class MelodyHubDbContext(DbContextOptions<MelodyHubDbContext> options) 
    : DbContext(options), IMelodyHubDbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserProject> UserProjects { get; set; } = null!;
    public DbSet<UserFavorite> UserFavorites { get; set; } = null!;
    public DbSet<BlogArticle> BlogArticles { get; set; } = null!;
    public DbSet<ArticleComment> ArticleComments { get; set; } = null!;
    public DbSet<Instrument> Instruments { get; set; } = null!;
    public DbSet<InstrumentCategory> InstrumentCategories { get; set; } = null!;
    public DbSet<InstrumentMaterial> InstrumentMaterials { get; set; } = null!;
    public DbSet<Material> Materials { get; set; } = null!;
    public DbSet<Blueprint> Blueprints { get; set; } = null!;
    public DbSet<Quiz> Quizzes { get; set; } = null!;
    public DbSet<QuizQuestion> QuizQuestions { get; set; } = null!;
    public DbSet<QuizResult> QuizResults { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
