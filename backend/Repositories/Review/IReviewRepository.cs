using Microsoft.AspNetCore.Mvc;

namespace backend.Repositories.Review;

public interface IReviewRepository
{
   Task<List<Models.Review>> GetAll();
   Task<Models.Review?> GetById(int id);
   Task<Models.Review> CreateAsync(Models.Review review);
}