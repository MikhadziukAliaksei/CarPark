using AutoMapper;
using CarPark.Api.Mapper;
using CarPark.Bll.Services;
using CarPark.Contracts.Interfaces;
using CarPark.Entities.Models;
using CarPark.EntitiesDto;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CarPark.UnitTests
{
    [TestFixture]
    class CarServiceTest
    {
        private readonly IMapper _mapper;

        public CarServiceTest()
        {
            var config = new MapperConfiguration(cfg =>
            cfg.AddProfile(new MappingProfile()));
            _mapper = config.CreateMapper();
        }

        [Test]
        public void Create_Car_ShoudCreate()
        {
            // Arrange
            var carEntity = new CarForCreate()
            {
                Mark = "Audi",
                Model = "A7",
                Color = "Black",
                Quantity = 1,
                Price = 30000,
                ManufacturerCountryId = 1,
                YearOfIssue = 2000,
                IsDeleted = false
            };
            var carList = new List<Car> { };

            var carMockRepo = new Mock<IRepositoryManager>();
            carMockRepo.Setup(x => x.Car.GetCars(true)).Returns(carList);
            carMockRepo.Setup(x => x.Car.CreateCar(It.IsAny<Car>())).Callback<Car>(e => carList.Add(e));
            var carValid = new CarService(carMockRepo.Object);

            // Act
            carValid.CreateCar(_mapper.Map<Car>(carEntity));

            // Assert
            carMockRepo.Object.Car.GetCars(true).Should().NotBeEmpty();
        }

        [Test]
        public void Delete_ExistCar_FieldIsDeteledShouldSetTrue()
        {
            var carEntity = new Car
            {
                Id = 333,
                Mark = "Audi",
                Model = "A7",
                Color = "Black",
                Quantity = 1,
                Price = 30000,
                ManufacturerCountryId = 1,
                CarSpecificationId = 1,
                YearOfIssue = 2000,
                IsDeleted = false
            };

            var carList = new List<Car> {
                carEntity
            };

            var carMockRepo = new Mock<IRepositoryManager>();
            carMockRepo.Setup(x => x.Car.GetCars(false)).Returns(carList);
            carMockRepo.Setup(x => x.Car.DeleteCar(It.IsAny<int>(), It.IsAny<bool>())).Callback<int, bool>((e , r) => carList.Find(item => item.Id == e).IsDeleted = true);
            var carValid = new CarService(carMockRepo.Object);


            carValid.DeleteCar(carEntity, true);


            Assert.AreEqual(carEntity.IsDeleted, true);
        }

        [Test]
        public void Get_GetCars_ShouldReturnCars()
        {
            var carList = new List<Car>
            {
                new Car
                {
                    Id = 333,
                    Mark = "Audi",
                    Model = "A7",
                    Color = "Black",
                    Quantity = 1,
                    Price = 30000,
                    ManufacturerCountryId = 1,
                    CarSpecificationId = 1,
                    YearOfIssue = 2000,
                    IsDeleted = false
                },
                new Car
                {
                    Id = 111,
                    Mark = "Audi",
                    Model = "A7",
                    Color = "Black",
                    Quantity = 1,
                    Price = 30000,
                    ManufacturerCountryId = 1,
                    CarSpecificationId = 1,
                    YearOfIssue = 2000,
                    IsDeleted = true
                }
            };

            var carMockRepo = new Mock<IRepositoryManager>();
            carMockRepo.Setup(x => x.Car.GetCars(false)).Returns(carList);
            var carValid = new CarService(carMockRepo.Object);

            Assert.IsNotEmpty(carValid.GetCars(false));
        }



        [Test]
        public void Get_GetCar_ShouldReturnCar()
        {
            var carList = new List<Car>
            {
                new Car
                {
                    Id = 333,
                    Mark = "Audi",
                    Model = "A7",
                    Color = "Black",
                    Quantity = 1,
                    Price = 30000,
                    ManufacturerCountryId = 1,
                    CarSpecificationId = 1,
                    YearOfIssue = 2000,
                    IsDeleted = false
                },
                new Car
                {
                    Id = 111,
                    Mark = "Audi",
                    Model = "A7",
                    Color = "Black",
                    Quantity = 1,
                    Price = 30000,
                    ManufacturerCountryId = 1,
                    CarSpecificationId = 1,
                    YearOfIssue = 2000,
                    IsDeleted = true
                }
            };

            var carMockRepo = new Mock<IRepositoryManager>();
            carMockRepo.Setup(x => x.Car.GetCar(It.IsAny<int>(), It.IsAny<bool>())).Callback<int, bool>((e , r) => carList.Find(item => item.Id == 333)).Returns(carList.Find(e => e.Id == 333));
            var carValid = new CarService(carMockRepo.Object);


            var res  = carValid.GetCar(333, false);


            Assert.IsNotNull(res);
        }

        [Test]
        public void Get_GetCarWithInvalidId_ShouldReturnNull()
        {
            var carList = new List<Car>
            {
                new Car
                {
                    Id = 333,
                    Mark = "Audi",
                    Model = "A7",
                    Color = "Black",
                    Quantity = 1,
                    Price = 30000,
                    ManufacturerCountryId = 1,
                    CarSpecificationId = 1,
                    YearOfIssue = 2000,
                    IsDeleted = false
                },
                new Car
                {
                    Id = 111,
                    Mark = "Audi",
                    Model = "A7",
                    Color = "Black",
                    Quantity = 1,
                    Price = 30000,
                    ManufacturerCountryId = 1,
                    CarSpecificationId = 1,
                    YearOfIssue = 2000,
                    IsDeleted = true
                }
            };

            var carMockRepo = new Mock<IRepositoryManager>();
            carMockRepo.Setup(x => x.Car.GetCar(It.IsAny<int>(), It.IsAny<bool>())).Callback<int, bool>((e, r) => carList.Find(item => item.Id == 333)).Returns(carList.Find(e => e.Id == 123));
            var carValid = new CarService(carMockRepo.Object);


            var res = carValid.GetCar(123, false);


            Assert.IsNull(res);
        }
    }
}
