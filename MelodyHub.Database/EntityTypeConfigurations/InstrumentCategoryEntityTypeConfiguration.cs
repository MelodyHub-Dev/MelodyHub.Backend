using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelodyHub.Database.EntityTypeConfigurations;

public class InstrumentCategoryEntityTypeConfiguration : IEntityTypeConfiguration<InstrumentCategory>
{
    public void Configure(EntityTypeBuilder<InstrumentCategory> builder)
    {
        builder.HasKey(ic => ic.Id);

        builder.HasIndex(ic => ic.Name).IsUnique();
        builder.HasIndex(ic => ic.Slug).IsUnique();

        builder.Property(ic => ic.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(ic => ic.Description)
            .HasMaxLength(1000);

        builder.Property(ic => ic.Slug)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasMany(ic => ic.Instruments)
            .WithOne(i => i.Category)
            .HasForeignKey(i => i.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
