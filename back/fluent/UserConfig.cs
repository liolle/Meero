using meero.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace entity.fluent;

public class UserConfig : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder
            .Property(user=>user.Name)
            .IsRequired(false)
            .HasMaxLength(50);
        
        builder
            .Property(user=>user.Email)
            .IsRequired(true)
            .HasMaxLength(200);
        
        builder
            .Property(user=>user.Password)
            .IsRequired(true)
            .HasMaxLength(1000);
        
        builder
            .Property(user=>user.Role)
            .HasConversion<string>()
            .IsRequired(true);
    }

}