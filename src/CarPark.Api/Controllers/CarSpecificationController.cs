using AutoMapper;
using CarPark.Contracts.Interfaces.Logger;
using CarPark.Contracts.Services;
using CarPark.Entities.Models;
using CarPark.EntitiesDto.CarSpecification;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.Api.Controllers
{
    [Route("api/cars/{carId}/specifications")]
    [ApiController]
    public class CarSpecificationController : ControllerBase
    {
        private readonly ICarSpecificationService _specificationService;
        private readonly ICarService _carService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CarSpecificationController(ICarSpecificationService specificationService,
            ILoggerManager logger,
            ICarService carService,
            IMapper mapper)
        {
            _specificationService = specificationService;
            _logger = logger;
            _carService = carService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateSpecificationForCar([FromBody] SpecificationForCarDto specificationForCar, int carId)
        {
            if (specificationForCar == null)
            {
                _logger.LogError($"specificationForCar object sent from client is null");
                return BadRequest("specificationForCar object is null");
            }

            var car = _carService.GetCar(carId, false);
            if (car == null)
            {
                _logger.LogInfo($"Car with id: {carId} doesn't exist in the database");
                return NotFound();
            }

            var specificationEntity = _mapper.Map<CarSpecification>(specificationForCar);
            _specificationService.CreateSpecificationForCar(specificationEntity, carId);
            var specificationToReturn = _mapper.Map<CarSpecificationDto>(specificationEntity);

            return CreatedAtRoute("GetSpecificationForCar", new { carId, id = specificationToReturn.Id }, specificationToReturn);
        }

        [HttpGet("{id}", Name = "GetSpecificationForCar")]
        public IActionResult GetCarSpecification(int carId, int id)
        {
            var car = _carService.GetCar(carId, false);
            if (car == null)
            {
                _logger.LogError($"Car with id: {carId} doest't exist in the database");
                return NotFound();
            }
            var specification = _specificationService.GetCarSpecification(carId, id, trackChanges: false);

            if (specification == null)
            {
                _logger.LogInfo($"Car specification with id: {id} doesn't exist in the database");
                return NotFound();
            }

            var carSpecification = _mapper.Map<CarSpecificationDto>(specification);

            return Ok(carSpecification);
        }
    }
}
