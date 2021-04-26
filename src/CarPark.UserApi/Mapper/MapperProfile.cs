using AutoMapper;
using CarPark.Entities.Models.Identity;
using CarPark.EntitiesDto.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.UserApi.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserForRegisterDto, User>().ReverseMap();
        }
    }
}
