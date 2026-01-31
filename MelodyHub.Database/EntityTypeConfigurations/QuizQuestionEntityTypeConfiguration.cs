using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelodyHub.Database.EntityTypeConfigurations;

public class QuizQuestionEntityTypeConfiguration : IEntityTypeConfiguration<QuizQuestion>
{
    public void Configure(EntityTypeBuilder<QuizQuestion> builder)
    {
        // Таблица
        builder.ToTable("QuizQuestions");

        // Первичный ключ
        builder.HasKey(qq => qq.Id);

        // Индексы
        builder.HasIndex(qq => qq.QuizId);

        // Свойства
        builder.Property(qq => qq.QuestionText)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(qq => qq.OptionA)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(qq => qq.OptionB)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(qq => qq.OptionC)
            .HasMaxLength(500);

        builder.Property(qq => qq.OptionD)
            .HasMaxLength(500);

        builder.Property(qq => qq.CorrectAnswer)
            .IsRequired()
            .HasColumnType("char(1)");

        builder.Property(qq => qq.Explanation)
            .HasMaxLength(1000);

        builder.Property(qq => qq.Points)
            .IsRequired()
            .HasDefaultValue((byte)10);

        // Связь с Quiz
        builder.HasOne(qq => qq.Quiz)
            .WithMany(q => q.Questions)
            .HasForeignKey(qq => qq.QuizId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
