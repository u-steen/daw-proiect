using AutoMapper;
using backend.Data;
using backend.DTO.Movie;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/movie")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly IMapper _mapper;
    public MovieController(ApplicationDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
        var movieDto = _mapper.Map<MovieDto>(movie);
        return Ok(movieDto);
    }
}