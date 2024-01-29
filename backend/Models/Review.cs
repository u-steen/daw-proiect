using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("Reviews")]
public class Review
{
    public int? MovieId { get; set; }
    public Movie? Movie { get; set; }

    public int Id { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
    public DateTime TimpCreare { get; set; }
}
