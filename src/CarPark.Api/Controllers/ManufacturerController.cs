using AutoMapper;
using CarPark.Contracts.Interfaces.Logger;
using CarPark.Contracts.Services;
using CarPark.Entities.Models;
using CarPark.EntitiesDto.Manufacturer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public ManufacturerController(IManufacturerService manufacturerService, IMapper mapper, ILoggerManager logger)
        {
            _manufacturerService = manufacturerService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Get manufacturers list")]
        public IActionResult GetManufacturers()
        {
            try
            {
                var manufacturers = _manufacturerService.GetManufacturers(trackChanges: false);
                return Ok(manufacturers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetManufacturers)} action {ex}");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}", Name = "ManufacturerById")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get manufacturer country by id")]
        public IActionResult GetManufacturer(int id)
        {
            var manufacturer = _manufacturerService.GetManufacturer(id, trackChanges: false);
            if (manufacturer == null)
            {
                _logger.LogInfo($"Manufacturer with id: {id} doesn't exist in the database");
                return NotFound();
            }
            return Ok(manufacturer);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Create new manufacturer country")]
        public IActionResult CreateManufacturer([FromBody] ManufacturerForCreateDto manufacturer)
        {
            if (manufacturer == null)
            {
                _logger.LogError($"Manufacturer object sent from client is null");
                return BadRequest("Manufacturer object is null");
            }

            var manufacturerEntity = _mapper.Map<ManufacturerCountry>(manufacturer);
            _manufacturerService.CreateManufacturer(manufacturerEntity);

            var manufacturerToReturn = _mapper.Map<ManufacturerDto>(manufacturerEntity);
            return CreatedAtRoute("ManufacturerById", new { id = manufacturerToReturn.Id }, manufacturerToReturn);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Delete manufacturer country ")]
        public IActionResult DeleteManufacturer(int id)
        {
            var manufacturer = _manufacturerService.GetManufacturer(id, trackChanges: false);
            if (manufacturer == null)
            {
                _logger.LogInfo($"Manufacturer with id: {id} doesn't exist in the database");
                return NotFound();
            }

            _manufacturerService.DeleteManufacturer(manufacturer);

            return NoContent();
        }

        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerOperation(Summary = "Update manufacturer country")]
        public IActionResult UpdateManufacturer(int id, [FromBody] ManufacturerForUpdateDto manufacturerForUpdate)
        {
            if (manufacturerForUpdate == null)
            {
                _logger.LogError("ManufacturerForUpdate object sent from client is null.");
                return BadRequest("ManufacturerForUpdate object is null");
            }

            var manufacturerEntity = _manufacturerService.GetManufacturer(id, true);

            if (manufacturerEntity == null)
            {
                _logger.LogInfo($"Manufacturer with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(manufacturerForUpdate, manufacturerEntity);
            _manufacturerService.UpdateManufacturer();

            return NoContent();
        }
    }
}
