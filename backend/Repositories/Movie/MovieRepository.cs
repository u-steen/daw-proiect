using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.DTO.Movie;

namespace backend.Repositories.Movie;

public class MovieRepository : IMovieRepository
{
    private readonly ApplicationDBContext _context;
    public MovieRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<List<Models.Movie>> GetAllAsync()
    {
        return await _context.Movies.Include(m => m.Reviews).ToListAsync();
    }

    public async Task<Models.Movie?> GetByIdAsync(int id)
    {
        return await _context.Movies.Include(m => m.Reviews).FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Models.Movie> CreateMovieAsync(Models.Movie movie)
    {
        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();
        return movie;
    }

    public async Task<Models.Movie?> UpdateMovieAsync(int id, UpdateMovieDto updatedMovie)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
        if (movie == null)
        {
            return null;
        }

        movie.Titlu = updatedMovie.Titlu;
        movie.Director= updatedMovie.Director;
        movie.An= updatedMovie.An;
        // TODO: Categorii

        await _context.SaveChangesAsync();
        return movie;
    }

    public async Task<Models.Movie?> DeleteMovieAsync(int id)
    {

        var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
        if (movie == null)
        {
            return null;
        }
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return movie;
    }

    public Task<bool> MovieExists(int id)
    {
        return _context.Movies.AnyAsync(m => m.Id == id);
    }
}
