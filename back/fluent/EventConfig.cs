using meero.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace entity.fluent;

public class EventConfig : IEntityTypeConfiguration<EventEntity>
{
    public void Configure(EntityTypeBuilder<EventEntity> builder)
    {
        builder.ToTable("Events");

        builder
            .Property(e=> e.Title)
            .HasMaxLength(200)
            .IsRequired(true);
        
        builder
            .Property(e=> e.Description)
            .HasMaxLength(1000)
             .IsRequired(false);
        
        builder
            .Property(e => e.Date)
            .IsRequired();

        builder
            .Property(e => e.Duration)
            .IsRequired();


        
        builder
            .Property(e => e.LocationId)
            .IsRequired();

        builder
            .HasOne(e => e.Location)  
            .WithMany()               
            .HasForeignKey(e => e.LocationId)  
            .OnDelete(DeleteBehavior.Cascade); 
        
        builder
            .HasMany(e => e.Attendants)
            .WithMany(e => e.Events)
            // create an other entity to further control the many to many relation (ex. UserEventEntity).
            // User implicit join table.
            // Use this to control deletion behavior
            // OnDelete scoped to the join table.
            .UsingEntity<Dictionary<string, object>>(
                "EventAttendants",
                j => j.HasOne<UserEntity>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade),
                // When an EventEntity is deleted, all related records in the join table will also be deleted automatically.
                j => j.HasOne<EventEntity>().WithMany().HasForeignKey("EventId").OnDelete(DeleteBehavior.Cascade) 
            );

        builder
            .HasMany(e => e.Heroes)
            .WithMany(e => e.Events)
            .UsingEntity<Dictionary<string, object>>(
                "EventHeroes",
                j => j.HasOne<HeroEntity>().WithMany().HasForeignKey("HeroId").OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<EventEntity>().WithMany().HasForeignKey("EventId").OnDelete(DeleteBehavior.Cascade) 
            );

    }
}