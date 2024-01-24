using backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Review;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDBContext _context;
    public ReviewRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<List<Models.Review>> GetAll()
    {
        return await _context.Reviews.ToListAsync();
    }
}