using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelodyHub.Database.EntityTypeConfigurations;

public class QuizResultEntityTypeConfiguration : IEntityTypeConfiguration<QuizResult>
{
    public void Configure(EntityTypeBuilder<QuizResult> builder)
    {
        builder.ToTable("QuizResults");

        builder.HasKey(qr => qr.Id);

        builder.HasIndex(qr => qr.UserId);
        builder.HasIndex(qr => qr.QuizId);
        builder.HasIndex(qr => qr.CompletedAt);

        builder.Property(qr => qr.Score)
            .IsRequired();

        builder.Property(qr => qr.MaxScore)
            .IsRequired();

        builder.HasOne(qr => qr.User)
            .WithMany(u => u.QuizResults)
            .HasForeignKey(qr => qr.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(qr => qr.Quiz)
            .WithMany(q => q.Results)
            .HasForeignKey(qr => qr.QuizId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
