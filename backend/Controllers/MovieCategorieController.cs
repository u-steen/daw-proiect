using backend.Repositories.Categorie;
using backend.Repositories.Movie;
using backend.Repositories.MovieCategorie;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("movie-categorie")]
[ApiController]
public class MovieCategorieController : ControllerBase
{
    private readonly IMovieRepository _movieRepo;
    private readonly ICategorieRepository _categorieRepo;
    private readonly IMovieCategorieRepository _mcRepo;

    public MovieCategorieController(
        IMovieRepository movieRepo,
        ICategorieRepository categorieRepo,
        IMovieCategorieRepository mcRepo)
    {
        _movieRepo = movieRepo;
        _categorieRepo = categorieRepo;
        _mcRepo = mcRepo;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll(int movieId)
    {
        var categorii = await _mcRepo.GetMovieCategorii(movieId);
        if (categorii == null)
            return BadRequest("Filmul nu exita");
        return Ok(categorii);
    }
}