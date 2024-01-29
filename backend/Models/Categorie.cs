using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("Categorii")]
public class Categorie
{
    public int Id { get; set; }
    public string Nume { get; set; } = string.Empty;

    public List<MovieCategorie> MovieCategorii { get; set; } = new List<MovieCategorie>();
}
