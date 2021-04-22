using CarPark.Contracts.Interfaces;
using CarPark.Contracts.Interfaces.Logger;
using CarPark.Contracts.Services;
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

        public CarsController(ICarService carService, ILoggerManager logger)
        {
            _carService = carService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            try
            {
                var cars = _carService.GetCars(trackChanges: false);
                return Ok(cars);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCars)} action {ex}");
                return StatusCode(500);
            }
            

        }
    }
}
