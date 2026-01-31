using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelodyHub.Database.EntityTypeConfigurations;

public class InstrumentMaterialEntityTypeConfiguration : IEntityTypeConfiguration<InstrumentMaterial>
{
    public InstrumentMaterialEntityTypeConfiguration()
    {
    }

    public void Configure(EntityTypeBuilder<InstrumentMaterial> builder)
    {
        // Таблица
        builder.ToTable("InstrumentMaterials");

        // Составной первичный ключ
        builder.HasKey(im => new { im.InstrumentId, im.MaterialId });

        // Свойства
        builder.Property(im => im.Quantity)
            .IsRequired()
            .HasColumnType("decimal(10,2)")
            .HasDefaultValue(1.00m);

        builder.Property(im => im.Notes)
            .HasMaxLength(1000);

        // Связь с Instrument
        builder.HasOne(im => im.Instrument)
            .WithMany(i => i.InstrumentMaterials)
            .HasForeignKey(im => im.InstrumentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с Material
        builder.HasOne(im => im.Material)
            .WithMany(m => m.InstrumentMaterials)
            .HasForeignKey(im => im.MaterialId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
