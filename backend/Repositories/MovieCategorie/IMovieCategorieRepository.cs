namespace backend.Repositories.MovieCategorie;

using Models;

public interface IMovieCategorieRepository
{
    Task<List<Categorie>> GetMovieCategorii(int movieId);
}