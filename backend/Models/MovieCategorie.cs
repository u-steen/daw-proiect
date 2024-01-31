using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("MovieCategorii")]
public class MovieCategorie
{
    [Key, Column(Order=0)]
    public int MovieId { get; set; }
    [Key, Column(Order=1)]
    public int CategorieId { get; set; }

    // Navigation props
    public Movie? Movie{ get; set; }
    public Categorie? Categorie{ get; set; }
}
