using AutoMapper;
using CarPark.Contracts.Interfaces.Logger;
using CarPark.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarParkController : ControllerBase
    {

        private readonly ICarParkService _carParkService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CarParkController(IMapper mapper, ILoggerManager logger, ICarParkService carParkService)
        {
            _mapper = mapper;
            _logger = logger;
            _carParkService = carParkService;
        }


    }
}
