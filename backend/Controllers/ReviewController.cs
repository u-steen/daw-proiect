using AutoMapper;
using backend.DTO.Movie;
using backend.DTO.Review;
using backend.Repositories.Review;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/review")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewRepository _repo;
    private readonly IMapper _mapper;

    public ReviewController(IReviewRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reviews = await _repo.GetAll();
        var reviewsDto = reviews.Select(review => _mapper.Map<ReviewDto>(review)).ToList();
        return Ok(reviewsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var review = await _repo.GetById(id);
        if (review == null)
            return NotFound();
        return Ok(_mapper.Map<ReviewDto>(review));
    }

}