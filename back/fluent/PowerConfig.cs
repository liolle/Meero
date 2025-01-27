using meero.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace entity.fluent;


public class PowerConfig : IEntityTypeConfiguration<PowerEntity>
{
    public void Configure(EntityTypeBuilder<PowerEntity> builder)
    {
        builder.ToTable("Powers");

        builder
            .HasIndex(power=>power.name)
            .IsUnique();

        builder
            .Property(power=>power.name)
            .IsRequired(true)
            .HasMaxLength(200);
    }
}