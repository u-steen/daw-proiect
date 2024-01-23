namespace backend.DTO.Movie;

public class CreateMovieDto
{
    public string Titlu { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int An { get; set; }
}