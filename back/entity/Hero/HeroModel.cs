using System.ComponentModel.DataAnnotations;
namespace meero.entity;

public class HeroModel
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Alias is required.")]
    [StringLength(50, ErrorMessage = "Alias cannot exceed 50 characters.")]
    public required string Alias { get; set; }

    [StringLength(500, ErrorMessage = "Bio cannot exceed 500 characters.")]
    public string? Bio { get; set; }

    [Url(ErrorMessage = "Please provide a valid URL for the profile image.")]
    [Display(Name = "Profile Image URL")]
    public string? ProfileImage { get; set; }

    [Required(ErrorMessage = "At least one power must be selected.")]
    [Display(Name = "Selected Powers")]
    public List<int> SelectedPowerIds { get; set; } = new List<int>();
}