using AutoMapper;
using backend.Data;
using backend.DTO.Movie;
using backend.Models;
using backend.Repositories.Movie;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/movie")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly IMapper _mapper;
    private readonly IMovieRepository _movieRepo;
    public MovieController(ApplicationDBContext context, IMapper mapper, IMovieRepository movieRepo)
    {
        _context = context;
        _movieRepo = movieRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var movies = await _movieRepo.GetAllAsync();
        var moviesDto = movies.Select(movie => _mapper.Map<MovieDto>(movie)).ToList();
        return Ok(moviesDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMovie([FromRoute] int id)
    {
        // Preferam Find in loc de FirstOrDefault pt id
        var movie = await _movieRepo.GetByIdAsync(id);
        if (movie == null)
            return NotFound();
        var movieDto = _mapper.Map<MovieDto>(movie);
        return Ok(movieDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie([FromBody] CreateMovieDto createdMovie)
    {
        var movie = _mapper.Map<Movie>(createdMovie);
        await _movieRepo.CreateMovieAsync(movie);
        return CreatedAtAction(nameof(GetMovie), new { movie.Id }, _mapper.Map<MovieDto>(movie));
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateMovie([FromRoute] int id, [FromBody] UpdateMovieDto updatedMovie)
    {
        var movie = await _movieRepo.UpdateMovieAsync(id, updatedMovie);
        if (movie == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<MovieDto>(movie));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteMovie([FromRoute] int id)
    {
        var movie = await _movieRepo.DeleteMovieAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return NoContent();
    }
}
