using FoodOrderingSystem.Core.DTOs;
using FoodOrderingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodOrderingSystem.Api.Controllers
{
    /*[ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [HttpPost("register")]
        [SwaggerOperation(Summary = "Register user's details")]
        [SwaggerResponse(StatusCodes.Status200OK, "User registered successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error registering user")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Failed to register user")]
        public async Task<IActionResult> Register([FromForm] RegisterRequest request)
        {
            var result = await _authenticationService.RegisterAsync(request);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }


        [HttpGet("confirm-account")]
        [SwaggerOperation(Summary = "Confirm user's email")]
        [SwaggerResponse(StatusCodes.Status200OK, "Email confirmed successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid email confirmation link.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Failed to confirm email.")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var result = await _authenticationService.ConfirmEmailAsync(userId, token);

            if (result == "Email confirmed successfully")
            {
                return Ok(result);
            }
            else if (result == "Invalid email confirmation link.")
            {
                return BadRequest(result);
            }
            else if (result == "User not found.")
            {
                return NotFound(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result);
        }


        [HttpPost("login")]
        [SwaggerOperation(Summary = "Login to account")]
        [SwaggerResponse(StatusCodes.Status200OK, "User logged in successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error logging in user.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Failed to logged in account.")]
        public async Task<IActionResult> Login([FromForm] LoginRequest request)
        {
            var result = await _authenticationService.LoginAsync(request);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }


        [HttpPost("logout")]
        [SwaggerOperation(Summary = "Logout account")]
        [SwaggerResponse(StatusCodes.Status200OK, "User logged out successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error logging out user.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Failed to logged out account.")]
        public async Task<IActionResult> Logout()
        {
            var result = await _authenticationService.LogoutAsync();
            return Ok(result);
        }


        [HttpPost("forgot-password")]
        [SwaggerOperation(Summary = "Forgot password")]
        [SwaggerResponse(StatusCodes.Status200OK, "Forgot password forgotten email sent")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error in details entered.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Failed to re.")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto request)
        {
            var result = await _authenticationService.ForgotPasswordAsync(request);
            if (result == null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }*/




    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IAuthenticationService authenticationService, ILogger<AuthenticationController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }


        [HttpPost("register-user")]
        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {
            var newUser = await _authenticationService.Register(model);
            if (newUser == null)
            {
                _logger.LogError("Registration not successful");
                return BadRequest(new RegisterResponseDto { Errors = "Registration not successful" });
            }
            _logger.LogInformation("New registration successful");
            return StatusCode(201);
        }


        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            try
            {
                await _authenticationService.ConfirmEmailAsync(userId, token);
                return Ok("Email confirmed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticationRequestDto model)
        {
            var response = await _authenticationService.Authenticate(model);

            if (!response.IsAuthSuccessful)
            {
                _logger.LogError("Email not confirmed");
                return BadRequest("Email is not confirmed. Please check your email and confirm your account.");
            }
            if (response == null)
            {
                _logger.LogError("Invalid authentication detais");
                return Unauthorized(new AuthenticationResponseDto { ErrorMessage = "Invalid Authentication" });
            }
            _logger.LogInformation("user authentication successful");
            return Ok(new AuthenticationResponseDto { IsAuthSuccessful = true, AccessToken = response.AccessToken });
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authenticationService.Logout();
            return NoContent();
        }


        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto model)
        {
            await _authenticationService.ForgotPassword(model);
            return Ok();
        }


        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid credentials");
            }
            var result = await _authenticationService.ResetPassword(model);
            if (!result)
            {
                return BadRequest("Error Occurs");
            }
            return Ok();
        }
    }
}
