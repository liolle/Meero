using meero.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class LocationConfig: IEntityTypeConfiguration<LocationEntity>
{
    public void Configure(EntityTypeBuilder<LocationEntity> builder)
    {
        builder.ToTable("Locations");

        builder.Property(l=>l.Address)
            .HasMaxLength(200)
            .IsRequired(true);
        
        builder.Property(l=>l.City)
            .HasMaxLength(100)
            .IsRequired(true);
        
        builder.Property(l=>l.Country)
            .HasMaxLength(100)
            .IsRequired(true);

        builder.Property(l=>l.LocationImage)
            .HasDefaultValue("https://images.unsplash.com/photo-1589085947445-a491beee038d?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");
        
        builder.Property(l=>l.LocationImage);

        builder.Property(l=>l.IsVirtual)
            .IsRequired(true);
    }
}