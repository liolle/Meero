using System.ComponentModel.DataAnnotations;
namespace meero.entity;

public class HeroEntity
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public required string Alias {get;set;}
    public string? Bio { get; set; }
    public string? ProfileImage {get;set;} 

    // Hero powers
    public ICollection<PowerEntity> Powers { get; set; } = new List<PowerEntity>();
    public ICollection<EventEntity> Events {get;set;} = new List<EventEntity>();
}