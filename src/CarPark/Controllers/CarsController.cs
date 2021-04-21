using CarPark.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.Api.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        

    }
}
