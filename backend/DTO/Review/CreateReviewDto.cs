﻿namespace backend.DTO.Review;

public class CreateReviewDto
{
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
}