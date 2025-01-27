using System.ComponentModel.DataAnnotations;
namespace meero.entity;

public class PowerModel
{

    [Required(ErrorMessage = "Power name is required.")]
    [StringLength(50, ErrorMessage = "Power name cannot exceed 50 characters.")]
    public required string Name { get; set; }

}