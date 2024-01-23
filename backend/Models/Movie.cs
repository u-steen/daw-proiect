namespace backend.Models;

public class Movie
{
    public int Id { get; set; }
    public string Titlu { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int An { get; set; }
    // Many to One
    public List<Review> Reviews { get; set; }
    // Many to Many
    public List<Categorie> Categorii { get; set; }
}