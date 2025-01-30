using System.ComponentModel.DataAnnotations;
namespace meero.entity;

public class EventEntity
{
    [Key]
    public int Id {get;set;}

    public required string Title {get;set;}
    public string? Description {get;set;}

    public required DateTime Date {get;set;}

    public required int Duration {get;set;}

    public required int LocationId { get; set; }
    public LocationEntity Location { get; set; } = null!;

    public ICollection<UserEntity> Attendants {get;set;} = new List<UserEntity>();
    public ICollection<HeroEntity> Heroes {get;set;} = new List<HeroEntity>();

}