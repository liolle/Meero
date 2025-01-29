
using System.ComponentModel.DataAnnotations;
namespace meero.entity;

public class LocationModel {
    [Required]
    [StringLength(200, ErrorMessage = "Address length can't exceed 200 characters.")]
    public required string Address { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "City length can't exceed 100 characters.")]
    public required string City { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Country length can't exceed 100 characters.")]
    public required string Country { get; set; }

    [Url(ErrorMessage = "Invalid URL format.")]
    public string? LocationImage { get; set; }

    [Url(ErrorMessage = "Invalid URL format.")]
    public string? GoogleFrame { get; set; }

    public bool IsVirtual { get; set; }
}