using Microsoft.AspNetCore.Mvc;

namespace backend.Repositories.Review;

public interface IReviewRepository
{
   Task<List<Models.Review>> GetAll();
}