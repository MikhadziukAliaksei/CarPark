using AutoMapper;
using CarPark.Entities.Models;
using CarPark.EntitiesDto;
using CarPark.EntitiesDto.CarSpecification;

namespace CarPark.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarDto, Car>().ReverseMap();
            CreateMap<CarForCreate, Car>().ReverseMap();
            CreateMap<CarSpecificationDto, CarSpecification>().ReverseMap();
            CreateMap<SpecificationForCarDto, CarSpecification>().ReverseMap();
        }
    }
}
