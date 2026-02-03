using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelodyHub.Database.EntityTypeConfigurations;

public class BlueprintEntityTypeConfiguration : IEntityTypeConfiguration<Blueprint>
{
    public void Configure(EntityTypeBuilder<Blueprint> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasIndex(b => new { b.InstrumentId, b.StepNumber }).IsUnique();

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.Content)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(b => b.ImageUrl)
            .HasMaxLength(500);

        builder.Property(b => b.VideoUrl)
            .HasMaxLength(500);

        builder.Property(b => b.EstimatedTimeMinutes)
            .HasDefaultValue(null);

        builder.HasOne(b => b.Instrument)
            .WithMany(i => i.Blueprints)
            .HasForeignKey(b => b.InstrumentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
