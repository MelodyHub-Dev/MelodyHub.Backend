using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelodyHub.Database.EntityTypeConfigurations;

public class InstrumentEntityTypeConfiguration : IEntityTypeConfiguration<Instrument>
{
    public void Configure(EntityTypeBuilder<Instrument> builder)
    {
        // Таблица
        builder.ToTable("Instruments");

        // Первичный ключ
        builder.HasKey(i => i.Id);

        // Индексы
        builder.HasIndex(i => i.Name).IsUnique();
        builder.HasIndex(i => i.CategoryId);
        builder.HasIndex(i => i.Difficulty);

        // Свойства
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

        builder.Property(i => i.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(i => i.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // Связь с Category
        builder.HasOne(i => i.Category)
            .WithMany(c => c.Instruments)
            .HasForeignKey(i => i.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с Blueprints
        builder.HasMany(i => i.Blueprints)
            .WithOne(b => b.Instrument)
            .HasForeignKey(b => b.InstrumentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с UserProjects
        builder.HasMany(i => i.UserProjects)
            .WithOne(up => up.Instrument)
            .HasForeignKey(up => up.InstrumentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Связь с UserFavorites
        builder.HasMany(i => i.FavoritedBy)
            .WithOne(uf => uf.Instrument)
            .HasForeignKey(uf => uf.InstrumentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с InstrumentMaterials
        builder.HasMany(i => i.InstrumentMaterials)
            .WithOne(im => im.Instrument)
            .HasForeignKey(im => im.InstrumentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
