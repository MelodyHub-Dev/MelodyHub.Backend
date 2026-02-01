using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelodyHub.Database.EntityTypeConfigurations;

public class BlogArticleEntityTypeConfiguration : IEntityTypeConfiguration<BlogArticle>
{
    public void Configure(EntityTypeBuilder<BlogArticle> builder)
    {
        builder.ToTable("BlogArticles");

        builder.HasKey(ba => ba.Id);

        builder.HasIndex(ba => ba.Title);
        builder.HasIndex(ba => ba.AuthorId);
        builder.HasIndex(ba => ba.IsPublished);

        builder.Property(ba => ba.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(ba => ba.Content)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(ba => ba.Excerpt)
            .HasMaxLength(500);

        builder.Property(ba => ba.ImageUrl)
            .HasMaxLength(500);

        builder.Property(ba => ba.ViewsCount)
            .HasDefaultValue(0);

        builder.Property(ba => ba.IsPublished)
            .HasDefaultValue(true);

        builder.Property(ba => ba.PublishedAt)
            .HasColumnType("datetime");

        builder.HasOne(ba => ba.Author)
            .WithMany(u => u.AuthoredArticles)
            .HasForeignKey(ba => ba.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(ba => ba.Comments)
            .WithOne(c => c.Article)
            .HasForeignKey(c => c.ArticleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
