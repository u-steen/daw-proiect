using backend.Data;
using Microsoft.AspNetCore.Http.HttpResults;
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

    public async Task<Models.Review?> GetById(int id)
    {
        return await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Models.Review> CreateAsync(Models.Review review)
    {
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
        return review;
    }

    public async Task<Models.Review?> DeleteAsync(int id)
    {
        Models.Review review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
        if (review == null)
        {
            return null;
        }

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
        return review;
    }
}