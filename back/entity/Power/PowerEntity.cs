using System.ComponentModel.DataAnnotations;

namespace meero.entity;

public class PowerEntity
{
    [Key]
    public int Id { get; set; }
    public required string name {get;set;}
}