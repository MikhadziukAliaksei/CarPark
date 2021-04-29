using AutoMapper;
using CarPark.Contracts.Identity;
using CarPark.Contracts.Interfaces.Logger;
using CarPark.Entities.Models.Identity;
using CarPark.EntitiesDto.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace CarPark.UserApi.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authenticationManager;

        public AuthenticationController(ILoggerManager logger,
            IMapper mapper,
            UserManager<User> userManager,
            IAuthenticationManager authenticationManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _authenticationManager = authenticationManager;
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Register new user")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, userDto.Roles);

            return StatusCode(201);
        }

        [HttpPost("login")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation(Summary = "Register new user")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authenticationManager.ValidateUser(user))
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");

                return Unauthorized();
            }

            return Ok(new { Token = await _authenticationManager.CreateToken() });
        }

    }
}
