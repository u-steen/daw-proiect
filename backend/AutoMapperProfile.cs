using AutoMapper;
using backend.DTO.Categorie;
using backend.DTO.Movie;
using backend.DTO.Review;
using backend.Models;

namespace backend;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Movie, MovieDto>();
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<Review, ReviewDto>();
        CreateMap<CreateReviewDto, Review>();
        CreateMap<Categorie, CategorieDto>();
        CreateMap<CreateCategorieDto, Categorie>();
    }
}
