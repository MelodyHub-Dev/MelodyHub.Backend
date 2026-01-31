using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelodyHub.Database.EntityTypeConfigurations;

public class UserFavoriteTypeConfiguration : IEntityTypeConfiguration<UserFavorite>
{
    public void Configure(EntityTypeBuilder<UserFavorite> builder)
    {
        builder.ToTable("UserFavorites");

        builder.HasKey(uf => new { uf.UserId, uf.InstrumentId });

        builder.Property(uf => uf.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(uf => uf.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(uf => uf.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(uf => uf.Instrument)
            .WithMany(i => i.FavoritedBy)
            .HasForeignKey(uf => uf.InstrumentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
