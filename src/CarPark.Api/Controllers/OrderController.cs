using AutoMapper;
using CarPark.Contracts.Interfaces.Logger;
using CarPark.Contracts.Services;
using CarPark.Entities.Models;
using CarPark.EntitiesDto.Order;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarPark.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService, IMapper mapper, ILoggerManager logger)
        {
            _orderService = orderService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
                var order = _orderService.GetOrders(trackChanges: false);
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetOrders)} action {ex}");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}", Name = "OrderById")]
        public IActionResult GetOrder(int id)
        {
            var order = _orderService.GetOrder(id, trackChanges: false);
            if (order == null)
            {
                _logger.LogInfo($"Order with id: {id} doesn't exist in the database");
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderForCreateDto order)
        {
            if (order == null)
            {
                _logger.LogError($"Order object sent from client is null");
                return BadRequest("Order object is null");
            }

            var orderEntity = _mapper.Map<Order>(order);
            _orderService.CreateOrder(orderEntity);

            var orderToReturn = _mapper.Map<OrderDto>(orderEntity);
            return CreatedAtRoute("OrderById", new { id = orderToReturn.Id }, orderToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _orderService.GetOrder(id, trackChanges: false);
            if (order == null)
            {
                _logger.LogInfo($"Order with id: {id} doesn't exist in the database");
                return NotFound();
            }

            _orderService.DeleteOrder(order, trackChanges: true);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderForUpdateDto updateForUpdate)
        {
            if (updateForUpdate == null)
            {
                _logger.LogError("CarForUpdate object sent from client is null.");
                return BadRequest("CarForUpdate object is null");
            }

            var orderEntity = _orderService.GetOrder(id, true);

            if (orderEntity == null)
            {
                _logger.LogInfo($"Order with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(updateForUpdate, orderEntity);
            _orderService.UpdateOrder();

            return NoContent();
        }
    }
}
