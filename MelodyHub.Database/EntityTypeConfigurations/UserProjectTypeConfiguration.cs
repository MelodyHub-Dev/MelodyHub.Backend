using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelodyHub.Database.EntityTypeConfigurations;

public class UserProjectTypeConfiguration : IEntityTypeConfiguration<UserProject>
{
    public void Configure(EntityTypeBuilder<UserProject> builder)
    {
        builder.ToTable("UserProjects");

        builder.HasKey(up => up.Id);

        builder.HasIndex(up => new { up.UserId, up.Name }).IsUnique();

        builder.Property(up => up.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(up => up.Description)
            .HasMaxLength(1000);

        builder.Property(up => up.Status)
            .IsRequired();

        builder.Property(up => up.Progress)
            .HasDefaultValue((byte)0);

        builder.Property(up => up.StartDate)
            .HasColumnType("date");

        builder.Property(up => up.FinishDate)
            .HasColumnType("date");

        builder.Property(up => up.ActualCost)
            .HasColumnType("decimal(18,2)");

        builder.Property(up => up.Notes)
            .HasMaxLength(2000);

        builder.Property(up => up.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(up => up.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(up => up.User)
            .WithMany(u => u.Projects)
            .HasForeignKey(up => up.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(up => up.Instrument)
            .WithMany(i => i.UserProjects)
            .HasForeignKey(up => up.InstrumentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
