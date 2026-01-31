using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelodyHub.Database.EntityTypeConfigurations;

namespace MelodyHub.Database.EntityTypeConfigurations;

public class QuizEntityTypeConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.ToTable("Quizzes");

        // Первичный ключ
        builder.HasKey(q => q.Id);

        builder.HasIndex(q => q.Title);
        builder.HasIndex(q => q.Difficulty);
        builder.HasIndex(q => q.IsActive);

        builder.Property(q => q.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(q => q.Description)
            .HasMaxLength(1000);

        builder.Property(q => q.Difficulty)
            .IsRequired();

        builder.Property(q => q.IsActive)
            .HasDefaultValue(true);

        builder.Property(q => q.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasMany(q => q.Questions)
            .WithOne(qq => qq.Quiz)
            .HasForeignKey(qq => qq.QuizId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(q => q.Results)
            .WithOne(r => r.Quiz)
            .HasForeignKey(r => r.QuizId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
