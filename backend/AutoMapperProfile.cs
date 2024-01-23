using AutoMapper;
using backend.DTO.Movie;
using backend.Models;

namespace backend;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Movie, MovieDto>();
    }
}