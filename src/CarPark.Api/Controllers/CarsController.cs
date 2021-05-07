using AutoMapper;
using CarPark.Contracts.Interfaces.Logger;
using CarPark.Contracts.Services;
using CarPark.Entities.Models;
using CarPark.EntitiesDto;
using CarPark.EntitiesDto.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace CarPark.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly ICarSpecificationService _specificationService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CarsController(ICarService carService,
            ILoggerManager logger,
            IMapper mapper,
            ICarSpecificationService specificationService)
        {
            _carService = carService;
            _logger = logger;
            _mapper = mapper;
            _specificationService = specificationService;
        }

        
        [HttpGet( Name = "GetCars" )]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation(Summary = "Get cars without  deleted car")]
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
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get car by id")]
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
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerOperation(Summary = "Create new car")]
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

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Delete car ")]
        public IActionResult DeleteCar(int id) 
        {
            var car = _carService.GetCar(id, trackChanges: false);
            if (car == null)
            {
                _logger.LogInfo($"Car with id: {id} doesn't exist in the database");
                return NotFound();
            }

            _carService.DeleteCar(car, trackChanges: true);

            return NoContent();
        }

        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerOperation(Summary = "Update car")]
        public IActionResult UpdateCar(int id, [FromBody] CarForUpdate carForUpdate)
        {
            if (carForUpdate == null)
            {
                _logger.LogError("CarForUpdate object sent from client is null.");
                return BadRequest("CarForUpdate object is null");
            }

            var carEntity = _carService.GetCar(id, true);

            if (carEntity == null)
            {
                _logger.LogInfo($"Car with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(carForUpdate, carEntity);
            _carService.UpdateCar();

            return NoContent();
        }
    }
}
