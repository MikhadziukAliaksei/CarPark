using AutoMapper;
using CarPark.Contracts.Interfaces.Logger;
using CarPark.Contracts.Services;
using CarPark.Entities.Models;
using CarPark.EntitiesDto.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Get orders list")]
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
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get order by id")]
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
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Create new user order")]
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
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Delete order  ")]
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
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerOperation(Summary = "Update user order")]
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
