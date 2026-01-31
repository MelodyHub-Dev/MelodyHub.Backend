using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.Interfaces;

public interface IMelodyHubDbContext
{
    DbSet<User> Users { get; }
    DbSet<UserProject> UserProjects { get; }
    DbSet<UserFavorite> UserFavorites { get; }
    DbSet<BlogArticle> BlogArticles { get; }
    DbSet<ArticleComment> ArticleComments { get; }
    DbSet<Instrument> Instruments { get; }
    DbSet<InstrumentCategory> InstrumentCategories { get; }
    DbSet<InstrumentMaterial> InstrumentMaterials { get; }
    DbSet<Material> Materials { get; }
    DbSet<Blueprint> Blueprints { get; }
    DbSet<Quiz> Quizzes { get; }
    DbSet<QuizQuestion> QuizQuestions { get; }
    DbSet<QuizResult> QuizResults { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
