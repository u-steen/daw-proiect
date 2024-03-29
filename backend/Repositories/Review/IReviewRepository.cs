﻿using backend.DTO.Review;

namespace backend.Repositories.Review;

public interface IReviewRepository
{
    Task<List<Models.Review>> GetAll();
    Task<Models.Review?> GetById(int id);
    Task<Models.Review> CreateAsync(Models.Review review);
    Task<Models.Review?> DeleteAsync(int id);
    Task<Models.Review?> UpdateReviewAsync(int id, UpdateReviewDto updatedReview);
}
