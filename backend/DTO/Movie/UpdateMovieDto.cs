namespace backend.DTO.Movie;

public class UpdateMovieDto
{
    public string Titlu { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int An { get; set; }
}