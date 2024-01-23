using AutoMapper;
using backend.Data;
using backend.DTO.Movie;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> GetAll()
    {
        // TODO: Nu stiu daca trebuie si la moviesDto async
        var movies = await _context.Movies.ToListAsync();
        var moviesDto = movies.Select(movie => _mapper.Map<MovieDto>(movie)).ToList();
        return Ok(moviesDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovie([FromRoute] int id)
    {
        // Preferam Find in loc de FirstOrDefault pt id
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
            return NotFound();
        var movieDto = _mapper.Map<MovieDto>(movie);
        return Ok(movieDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie([FromBody] CreateMovieDto creaetdMovie)
    {
        var movie = _mapper.Map<Movie>(creaetdMovie);
        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMovie), new { movie.Id }, _mapper.Map<MovieDto>(movie));
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateMovie([FromRoute] int id, [FromBody] UpdateMovieDto updatedMovie)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        movie.Titlu = updatedMovie.Titlu;
        movie.Director= updatedMovie.Director;
        movie.An= updatedMovie.An;
        // TODO: Categorii

        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<MovieDto>(movie));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteMovie([FromRoute] int id)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}