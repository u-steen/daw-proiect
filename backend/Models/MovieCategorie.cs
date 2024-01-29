using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("MovieCategorii")]
public class MovieCategorie
{
    public int MovieId { get; set; }
    public int CategorieId { get; set; }

    // Navigation props
    public Movie? Movie{ get; set; }
    public Categorie? Categorie{ get; set; }
}
