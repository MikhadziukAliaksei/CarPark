using AutoMapper;
using CarPark.Contracts.Interfaces;
using CarPark.Contracts.Interfaces.Logger;
using CarPark.Contracts.Services;
using CarPark.Entities.Models;
using CarPark.EntitiesDto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarPark.Api.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CarsController(ICarService carService, ILoggerManager logger, IMapper mapper)
        {
            _carService = carService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            try
            {
                var cars = _carService.GetCars(trackChanges: false);
                return Ok(cars);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCars)} action {ex}");
                return StatusCode(500);
            }


        }

        [HttpGet("{id}", Name = "CarById")]
        public IActionResult GetCar(int id)
        {
            var car = _carService.GetCar(id, trackChanges: false);
            if (car == null)
            {
                _logger.LogInfo($"Car with id: {id} doesn't exist in the database");
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public IActionResult CreateCar([FromBody] CarForCreate car)
        {
            if (car == null)
            {
                _logger.LogError($"Car object sent from client is null");
                return BadRequest("Car object is null");
            }

            var carEntity = _mapper.Map<Car>(car);
            _carService.CreateCar(carEntity);

            var carToReturn = _mapper.Map<CarDto>(carEntity);
            return CreatedAtRoute("CarById", new { id = carToReturn.Id }, carToReturn);
        }
    }
}
