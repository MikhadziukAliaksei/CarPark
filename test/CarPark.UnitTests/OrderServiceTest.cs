using AutoMapper;
using CarPark.Api.Mapper;
using CarPark.Bll.Services;
using CarPark.Contracts.Interfaces;
using CarPark.Entities.Models;
using CarPark.EntitiesDto.Order;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CarPark.UnitTests
{
    [TestFixture]
    public class OrderServiceTest
    {
        private readonly IMapper _mapper;

        public OrderServiceTest()
        {
            var config = new MapperConfiguration(cfg =>
            cfg.AddProfile(new MappingProfile()));
            _mapper = config.CreateMapper();
        }

        [Test]
        public void Get_GetOrders_ShouldReturnOrder()
        {
            var orderList = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    OrderDate = DateTime.Now,
                    CarId = 1,
                    CarParkId = 1,
                    ClientId = 1,
                    IsDeleted = false
                },
                new Order
                {
                    Id = 2,
                    OrderDate = DateTime.Now,
                    CarId = 2,
                    CarParkId = 1,
                    ClientId = 2,
                    IsDeleted = false
                }
            };

            var orderMockRepo = new Mock<IRepositoryManager>();
            orderMockRepo.Setup(x => x.Order.GetOrders(false)).Returns(orderList);
            var orderValid = new OrderService(orderMockRepo.Object);

            Assert.IsNotEmpty(orderValid.GetOrders(false));
        }

        [Test]
        public void Get_GetOrder_ShouldReturnOrder()
        {
            var orderList = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    OrderDate = DateTime.Now,
                    CarId = 1,
                    CarParkId = 1,
                    ClientId = 1,
                    IsDeleted = false
                },
                new Order
                {
                    Id = 2,
                    OrderDate = DateTime.Now,
                    CarId = 2,
                    CarParkId = 1,
                    ClientId = 2,
                    IsDeleted = true
                }
            };

            var orderMockRepo = new Mock<IRepositoryManager>();
            orderMockRepo.Setup(x => x.Order.GetOrder(It.IsAny<int>(), It.IsAny<bool>())).Callback<int, bool>((e, r) => orderList.Find(item => item.Id == 2)).Returns(orderList.Find(e => e.Id == 2));
            var orderValid = new OrderService(orderMockRepo.Object);


            var res = orderValid.GetOrder(2, false);


            Assert.IsNotNull(res);
        }

        [Test]
        public void Delete_ExistOrder_FieldIsDeteledShouldSetTrue()
        {
            var orderEntity = new Order
            {
                Id = 1,
                OrderDate = DateTime.Now,
                CarId = 1,
                CarParkId = 1,
                ClientId = 1,
                IsDeleted = false
            };

            var orderList = new List<Order> {
                orderEntity
            };

            var carMockRepo = new Mock<IRepositoryManager>();
            carMockRepo.Setup(x => x.Order.GetOrders(false)).Returns(orderList);
            carMockRepo.Setup(x => x.Order.DeleteOrder(It.IsAny<int>(), It.IsAny<bool>())).Callback<int, bool>((e, r) => orderList.Find(item => item.Id == e).IsDeleted = true);
            var orderValid = new OrderService(carMockRepo.Object);


            orderValid.DeleteOrder(orderEntity, true);


            Assert.AreEqual(orderEntity.IsDeleted, true);
        }

        [Test]
        public void Create_Order_ShoudCreate()
        {
            // Arrange
            var orderEntity = new OrderForCreateDto()
            {
                OrderDate = DateTime.Now,
                CarId = 1,
                CarParkId = 1,
                ClientId = 1,
                IsDeleted = false
            };
            var orderList = new List<Order> { };

            var orderMockRepo = new Mock<IRepositoryManager>();
            orderMockRepo.Setup(x => x.Order.GetOrders(true)).Returns(orderList);
            orderMockRepo.Setup(x => x.Order.CreateOrder(It.IsAny<Order>())).Callback<Order>(e => orderList.Add(e));
            var orderValid = new OrderService(orderMockRepo.Object);

            // Act
            orderValid.CreateOrder(_mapper.Map<Order>(orderEntity));

            // Assert
            orderMockRepo.Object.Order.GetOrders(true).Should().NotBeEmpty();
        }
    }
}
