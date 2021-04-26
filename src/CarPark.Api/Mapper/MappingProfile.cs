using AutoMapper;
using CarPark.Entities.Models;
using CarPark.EntitiesDto;
using CarPark.EntitiesDto.Car;
using CarPark.EntitiesDto.CarSpecification;
using CarPark.EntitiesDto.Manufacturer;

namespace CarPark.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarDto, Car>().ReverseMap();
            CreateMap<CarForCreate, Car>().ReverseMap();
            CreateMap<CarForUpdate, Car>().ReverseMap();

            CreateMap<CarSpecificationDto, CarSpecification>().ReverseMap();
            CreateMap<SpecificationForCarDto, CarSpecification>().ReverseMap();

            CreateMap<ManufacturerDto, ManufacturerCountry>().ReverseMap();
            CreateMap<ManufacturerForCreateDto, ManufacturerCountry>().ReverseMap();
            CreateMap<ManufacturerForUpdateDto, ManufacturerCountry>().ReverseMap();
        }
    }
}
