using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.DTO.Movie;
using backend.Models;

namespace backend.Repositories.Movie;

public interface IMovieRepository
{
    Task<List<Models.Movie>> GetAllAsync();
    Task<Models.Movie?> GetByIdAsync(int id);
    Task<Models.Movie> CreateMovieAsync(Models.Movie movie);
    Task<Models.Movie?> UpdateMovieAsync(int id, UpdateMovieDto movieDto);
    Task<Models.Movie?> DeleteMovieAsync(int id);

}