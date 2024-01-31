namespace backend.Repositories.MovieCategorie;

using Models;

public interface IMovieCategorieRepository
{
    Task<List<Categorie>> GetMovieCategorii(int movieId);
    Task<MovieCategorie> CreateMovieCategorieAsync(MovieCategorie mc);
    Task<MovieCategorie> DeleteMovieCategorieAsync(int movieId, int categorieId);
}