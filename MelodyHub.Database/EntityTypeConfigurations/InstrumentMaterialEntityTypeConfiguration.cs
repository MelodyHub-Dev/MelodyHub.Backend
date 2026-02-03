using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelodyHub.Database.EntityTypeConfigurations;

public class InstrumentMaterialEntityTypeConfiguration : IEntityTypeConfiguration<InstrumentMaterial>
{
    public void Configure(EntityTypeBuilder<InstrumentMaterial> builder)
    {
        builder.HasKey(im => new { im.InstrumentId, im.MaterialId });

        builder.Property(im => im.Quantity)
            .IsRequired()
            .HasColumnType("decimal(10,2)")
            .HasDefaultValue(1.00m);

        builder.Property(im => im.Notes)
            .HasMaxLength(1000);

        builder.HasOne(im => im.Instrument)
            .WithMany(i => i.InstrumentMaterials)
            .HasForeignKey(im => im.InstrumentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(im => im.Material)
            .WithMany(m => m.InstrumentMaterials)
            .HasForeignKey(im => im.MaterialId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
