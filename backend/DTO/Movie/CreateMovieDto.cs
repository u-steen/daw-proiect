using System.ComponentModel.DataAnnotations;

namespace backend.DTO.Movie;

public class CreateMovieDto
{
    [Required]
    public string Titlu { get; set; } = string.Empty;
    [Required]
    public string Director { get; set; } = string.Empty;
    [Required]
    [Range(1500, 2050)]
    public int An { get; set; }
}
