using backend.DTO.Review;

namespace backend.DTO.Movie;

public class MovieDto
{
    public int Id { get; set; }
    public string Titlu { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int An { get; set; }
    public List<ReviewDto> Reviews { get; set; }
}