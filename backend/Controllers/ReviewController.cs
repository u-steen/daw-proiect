using System.Runtime.CompilerServices;
using AutoMapper;
using backend.DTO.Review;
using backend.Extensions;
using backend.Models;
using backend.Repositories.Movie;
using backend.Repositories.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/review")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewRepository _reviewRepo;
    private readonly IMovieRepository _movieRepo;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;

    public ReviewController(IReviewRepository reviewRepo, IMapper mapper, 
    IMovieRepository movieRepo, UserManager<AppUser> userManager)
    {
        _reviewRepo = reviewRepo;
        _movieRepo = movieRepo;
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var reviews = await _reviewRepo.GetAll();
        var reviewsDto = reviews.Select(review => _mapper.Map<ReviewDto>(review)).ToList();
        return Ok(reviewsDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var review = await _reviewRepo.GetById(id);
        if (review == null)
            return NotFound();
        return Ok(_mapper.Map<ReviewDto>(review));
    }

    [Authorize]
    [HttpPost("{movieId:int}")]
    public async Task<IActionResult> Create([FromRoute] int movieId, [FromBody] CreateReviewDto createdReview)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!await _movieRepo.MovieExists(movieId))
        {
            return BadRequest("Movie does not exist");
        }

        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);

        var review = _mapper.Map<Review>(createdReview);
        review.AppUser = appUser;
        review.MovieId = movieId;
        await _reviewRepo.CreateAsync(review);
        return CreatedAtAction(nameof(GetById), new { id = review.Id }, _mapper.Map<ReviewDto>(review));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        Review? review = await _reviewRepo.DeleteAsync(id);
        if (review == null)
        {
            return NotFound("Not found");
        }

        return Ok(_mapper.Map<ReviewDto>(review));
    }
    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateReview([FromRoute] int id, [FromBody] UpdateReviewDto updatedReview)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var review = await _reviewRepo.UpdateReviewAsync(id, updatedReview);
        if (review == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<ReviewDto>(review));
    }
}
