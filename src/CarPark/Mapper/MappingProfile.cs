using AutoMapper;
using CarPark.Entities.Models;
using CarPark.EntitiesDto;

namespace CarPark.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarDto, Car>().ReverseMap();
            CreateMap<CarForCreate, Car>().ReverseMap();
        }
    }
}
