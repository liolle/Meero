using System.ComponentModel.DataAnnotations;
namespace meero.entity;

public class UserEntity
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required ERole Role { get; set; }
}