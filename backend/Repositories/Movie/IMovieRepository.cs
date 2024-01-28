using backend.DTO.Movie;

namespace backend.Repositories.Movie;

public interface IMovieRepository
{
    Task<List<Models.Movie>> GetAllAsync();
    Task<Models.Movie?> GetByIdAsync(int id);
    Task<Models.Movie> CreateMovieAsync(Models.Movie movie);
    Task<Models.Movie?> UpdateMovieAsync(int id, UpdateMovieDto movieDto);
    Task<Models.Movie?> DeleteMovieAsync(int id);
    Task<bool> MovieExists(int id);

}
