using AutoMapper;
using FPCMMS.Application.Contracts.Identity;
using FPCMMS.Application.Contracts.Service;
using FPCMMS.Application.DTOs.User;
using FPCMMS.Infrastructure.Identity.Models;
using FPCMMS.WebAPI.ActionFilters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FPCMMS.WebAPI.Controllers.Identity
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/authentications")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthenticationService _authManager;
        public AuthenticationsController(ILoggerManager logger, IMapper mapper, UserManager<ApplicationUser> userManager, IAuthenticationService authManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<ApplicationUser>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            if (!userForRegistration.Roles.Any())
            {
                _logger.LogInfo("Roles doesn't exist in the registration DTO object, adding the default one.");
                await _userManager.AddToRoleAsync(user, "Manager");
            }
            else
            {
                await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
            }

            return StatusCode(201);
        }


        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            var result = await _authManager.Login(user);

            if (result.Succeeded)
            {
                return Ok(new { WellCome = await _authManager.CreateToken() });
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Your account is locked out.");
                return StatusCode(423, "The account is locked out for 5 minutes");
            }
            else
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
                return Unauthorized();
            }
        }
    }
}