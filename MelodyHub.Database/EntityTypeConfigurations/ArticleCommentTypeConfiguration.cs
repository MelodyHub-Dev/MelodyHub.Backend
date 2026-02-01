using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelodyHub.Database.EntityTypeConfigurations;

public class ArticleCommentTypeConfiguration : IEntityTypeConfiguration<ArticleComment>
{
    public void Configure(EntityTypeBuilder<ArticleComment> builder)
    {
        builder.ToTable("ArticleComments");

        builder.HasKey(ac => ac.Id);

        builder.HasIndex(ac => ac.ArticleId);
        builder.HasIndex(ac => ac.UserId);
        builder.HasIndex(ac => ac.ParentCommentId);

        builder.Property(ac => ac.Content)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(ac => ac.IsApproved)
            .HasDefaultValue(true);

        builder.HasOne(ac => ac.Article)
            .WithMany(a => a.Comments)
            .HasForeignKey(ac => ac.ArticleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ac => ac.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(ac => ac.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ac => ac.ParentComment)
            .WithMany(pc => pc.Replies)
            .HasForeignKey(ac => ac.ParentCommentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
