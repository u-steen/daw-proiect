namespace backend.DTO.Review;

public class ReviewDto
{
    public int? MovieId { get; set; }

    public int Id { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
    public DateTime TimpCreare { get; set; }
    public string? CreatedBy { get; set; } = string.Empty;
}