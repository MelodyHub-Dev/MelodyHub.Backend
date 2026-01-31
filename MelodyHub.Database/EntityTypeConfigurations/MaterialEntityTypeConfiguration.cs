using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelodyHub.Database.EntityTypeConfigurations;

public class MaterialEntityTypeConfiguration : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        // Таблица
        builder.ToTable("Materials");

        // Первичный ключ
        builder.HasKey(m => m.Id);

        // Индексы
        builder.HasIndex(m => m.Name).IsUnique();
        builder.HasIndex(m => m.Category);

        // Свойства
        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(m => m.Description)
            .HasMaxLength(1000);

        builder.Property(m => m.Unit)
            .IsRequired();

        builder.Property(m => m.AvgPrice)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        builder.Property(m => m.Category)
            .HasMaxLength(200);

        builder.Property(m => m.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // Связь с InstrumentMaterials
        builder.HasMany(m => m.InstrumentMaterials)
            .WithOne(im => im.Material)
            .HasForeignKey(im => im.MaterialId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
