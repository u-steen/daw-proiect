using backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/movie")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public MovieController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var movies = _context.Movie.ToList();
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovie([FromRoute] int id)
    {
        // Preferam Find in loc de FirstOrDefault pt id
        var movie = _context.Movie.Find(id);
        if (movie == null)
            return NotFound();
        return Ok(movie);
    }
}