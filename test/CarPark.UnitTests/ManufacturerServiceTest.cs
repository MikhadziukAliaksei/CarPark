using AutoMapper;
using CarPark.Api.Mapper;
using CarPark.Bll.Services;
using CarPark.Contracts.Interfaces;
using CarPark.Entities.Models;
using CarPark.EntitiesDto.Manufacturer;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CarPark.UnitTests
{
    [TestFixture]
    public class ManufacturerServiceTest
    {
        private readonly IMapper _mapper;

        public ManufacturerServiceTest()
        {
            var config = new MapperConfiguration(cfg =>
            cfg.AddProfile(new MappingProfile()));
            _mapper = config.CreateMapper();
        }

        [Test]
        public void Create_ManufacturerCountry_ShoudCreate()
        {
            // Arrange
            var manufacturerEntity = new ManufacturerForCreateDto()
            {
                Name = "Belarus"
            };
            var ManumacturerList = new List<ManufacturerCountry> { };

            var manufactureMockRepo = new Mock<IRepositoryManager>();
            manufactureMockRepo.Setup(x => x.Manufacturer.GetManufacturers(true)).Returns(ManumacturerList);
            manufactureMockRepo.Setup(x => x.Manufacturer.CreateManufacturer(It.IsAny<ManufacturerCountry>()))
                .Callback<ManufacturerCountry>(e => ManumacturerList.Add(e));
            var manufacturerValid = new ManufacturerService(manufactureMockRepo.Object);

            // Act
            manufacturerValid.CreateManufacturer(_mapper.Map<ManufacturerCountry>(manufacturerEntity));

            // Assert
            manufactureMockRepo.Object.Manufacturer.GetManufacturers(true).Should().NotBeEmpty();
        }

        [Test]
        public void Delete_ExistManufacturer_ShouldDelete()
        {
            var manufacturerEntity = new ManufacturerCountry
            {
               Name = "Belarus"
            };

            var manufacturersList = new List<ManufacturerCountry> {
               new ManufacturerCountry
               {
                   Name = "Belarus"
               }
            };

            var manufacturerMockRepo = new Mock<IRepositoryManager>();
            manufacturerMockRepo.Setup(x => x.Manufacturer.GetManufacturers(false)).Returns(manufacturersList);
            manufacturerMockRepo.Setup(x => x.Manufacturer.DeleteManufacturer(It.IsAny<ManufacturerCountry>())).Callback<ManufacturerCountry>(e => manufacturersList.Remove(e));
            var manufacturerValid = new ManufacturerService(manufacturerMockRepo.Object);


            manufacturerValid.DeleteManufacturer(_mapper.Map<ManufacturerCountry>(manufacturerEntity));
            var res = manufacturerValid.GetManufacturers(true);

            Assert.IsEmpty(res);
        }
    }
}
