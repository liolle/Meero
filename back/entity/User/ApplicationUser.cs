namespace meero.entity;
public class ApplicationUser 
{
    // Additional properties for your user class can be added here
    public string? Name { get; set; }
    public required ERole Role { get; set; }
}