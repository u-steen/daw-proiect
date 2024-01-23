using AutoMapper;
using backend.Data;
using backend.DTO.Movie;
using backend.Models;
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
        var movies = _context.Movies.ToList();
        // Convertim fiecare film in dto-ul lui cu Linq
        var moviesDto = movies.Select(movie => _mapper.Map<MovieDto>(movie)).ToList();
        return Ok(moviesDto);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovie([FromRoute] int id)
    {
        // Preferam Find in loc de FirstOrDefault pt id
        var movie = _context.Movies.Find(id);
        if (movie == null)
            return NotFound();
        var movieDto = _mapper.Map<MovieDto>(movie);
        return Ok(movieDto);
    }

    [HttpPost]
    public IActionResult CreateMovie([FromBody] CreateMovieDto creaetdMovie)
    {
        var movie = _mapper.Map<Movie>(creaetdMovie);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovie), new { movie.Id }, _mapper.Map<MovieDto>(movie));
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateMovie([FromRoute] int id, [FromBody] UpdateMovieDto updatedMovie)
    {
        var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        movie.Titlu = updatedMovie.Titlu;
        movie.Director= updatedMovie.Director;
        movie.An= updatedMovie.An;
        // TODO: Categorii

        _context.SaveChanges();
        return Ok(_mapper.Map<MovieDto>(movie));
    }
}