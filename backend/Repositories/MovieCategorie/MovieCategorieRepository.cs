using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.MovieCategorie;

using Models;

public class MovieCategorieRepository : IMovieCategorieRepository
{
    private readonly ApplicationDBContext _context;

    public MovieCategorieRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<List<Categorie>> GetMovieCategorii(int movieId)
    {
        var movie = _context.Movies.FirstOrDefaultAsync(x => x.Id == movieId);
        return await _context.MovieCategorii
            .Where(mc => mc.MovieId == movie.Id)
            .Select(categorie => new Categorie
            {
                Id = categorie.CategorieId,
                Nume = categorie.Categorie.Nume,
                Descriere = categorie.Categorie.Descriere,
            })
            .ToListAsync();
    }
}