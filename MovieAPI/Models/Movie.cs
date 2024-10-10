using System.ComponentModel.DataAnnotations;

public class Movie
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    [MaxLength(255)]
    public string? ImageUrl { get; set; }
}
