using meero.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace entity.fluent;

public class HeroConfig : IEntityTypeConfiguration<HeroEntity>
{
    public void Configure(EntityTypeBuilder<HeroEntity> builder)
    {
        builder.ToTable("Heros");

        builder.Property(h => h.Alias)
            .IsRequired();
        
        builder.Property(h => h.Name)
            .HasMaxLength(100)
            .IsRequired(false);
        
        builder.Property(h => h.Bio)
            .HasMaxLength(2000)
            .IsRequired(false);

        builder.Property(h => h.ProfileImage)
            .HasDefaultValue("https://static.wikia.nocookie.net/p__/images/5/5b/Hero.jpeg/revision/latest?cb=20190130172753&path-prefix=protagonist");

        builder
            .HasMany(h => h.Powers)
            .WithMany();
    }
}