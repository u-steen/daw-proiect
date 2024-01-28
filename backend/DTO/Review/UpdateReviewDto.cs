using System.ComponentModel.DataAnnotations;

namespace backend.DTO.Review;

public class UpdateReviewDto
{
    [Required]
    [MinLength(10, ErrorMessage = "Review-ul trebuie sa aiba macar 10 caractere")]
    [MaxLength(500, ErrorMessage = "Review-ul trebuie sa aiba mai putin de 500 de caractere")]
    public string Comment { get; set; } = string.Empty;
    [Required]
    [Range(1, 10)]
    public int Rating { get; set; }
}
