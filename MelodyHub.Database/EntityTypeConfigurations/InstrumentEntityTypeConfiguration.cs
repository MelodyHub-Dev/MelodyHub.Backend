using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelodyHub.Database.EntityTypeConfigurations;

public class InstrumentEntityTypeConfiguration : IEntityTypeConfiguration<Instrument>
{
    public void Configure(EntityTypeBuilder<Instrument> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasIndex(i => i.CategoryId);
        builder.HasIndex(i => i.Difficulty);

        builder.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(i => i.Description)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(i => i.ShortDescription)
            .HasMaxLength(500);

        builder.Property(i => i.MainImageUrl)
            .HasMaxLength(500);

        builder.Property(i => i.EstimatedHours)
            .HasDefaultValue(null);

        builder.Property(i => i.ViewsCount)
            .HasDefaultValue(0);

        builder.HasOne(i => i.Category)
            .WithMany(c => c.Instruments)
            .HasForeignKey(i => i.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(i => i.Blueprints)
            .WithOne(b => b.Instrument)
            .HasForeignKey(b => b.InstrumentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(i => i.UserProjects)
            .WithOne(up => up.Instrument)
            .HasForeignKey(up => up.InstrumentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(i => i.FavoritedBy)
            .WithOne(uf => uf.Instrument)
            .HasForeignKey(uf => uf.InstrumentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(i => i.InstrumentMaterials)
            .WithOne(im => im.Instrument)
            .HasForeignKey(im => im.InstrumentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
