using FoodOrderingSystem.Core.DTOs;
using FoodOrderingSystem.Services.ImageService;
using FoodOrderingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodOrderingSystem.Api.Controllers
{
    /*[ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("get-users")]
        [SwaggerOperation(Summary = "get users")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all registered users")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error.")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            if (users == null)
            {
                return BadRequest();
            }
            return Ok(users);
        }


        [HttpGet("search-users")]
        [SwaggerOperation(Summary = "search users")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns searched users")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error.")]
        public async Task<IActionResult> SearchUsers(string searchTerm)
        {
            var searchedUsers = await _userService.SearchUsersAsync(searchTerm);
            if (searchedUsers == null)
            {
                return BadRequest();
            }
            return Ok(searchedUsers);
        }


        [HttpPut("update-user/{id}")]
        [SwaggerOperation(Summary = "Update user details")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the updated user")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error.")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] RegisterRequest request)
        {
            var updatedUser = await _userService.UpdateUserAsync(id, request);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }


        [HttpDelete("delete-user/{id}")]
        [SwaggerOperation(Summary = "Delete a user")]
        [SwaggerResponse(StatusCodes.Status200OK, "User deleted successfully.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error.")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok("User deleted successfully.");
        }


        [HttpPut("deactivate-user/{id}")]
        [SwaggerOperation(Summary = "Deactivate a user")]
        [SwaggerResponse(StatusCodes.Status200OK, "User deactivated successfully.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error.")]
        public async Task<IActionResult> DeactivateUser(string id)
        {
            var result = await _userService.DeactivateUserAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok("User deactivated successfully.");
        }


        [HttpPost("add-user-to-role")]
        [SwaggerOperation(Summary = "Add a user to a role")]
        [SwaggerResponse(StatusCodes.Status200OK, "User assigned to role successfully.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "User or role not found.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error.")]
        public async Task<IActionResult> AddUserToRole([FromBody] AddUserToRoleRequest request)
        {
            var result = await _userService.AddUserToRoleAsync(request);
            if (result.Contains("not found"))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }*/


    /*[ApiController]
    [Authorize]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IImageUploadService _imageService;

        public UserController(IUserService userService, IWebHostEnvironment webHostEnvironment, IImageUploadService imageService)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
            _imageService = imageService;
        }


        [HttpPost("add-admin-img")]
        public async Task<ActionResult<RegisterDto>> CreateAdminUserWithImage(RegisterDto model, IFormFile formFile)
        {
            var imageString = await _imageService.UploadImage(formFile);
            var createdUser = await _userService.AddAdminUser(model, imageString);

            if (createdUser != null)
            {
                return Ok(createdUser);
            }
            return BadRequest("Error occurs");
        }


        [HttpPost("add-admin")]
        public async Task<ActionResult<RegisterDto>> CreateAdminUser(RegisterDto model, IFormFile formFile)
        {
            var imageString = await _imageService.UploadImage(formFile);
            var createdUser = await _userService.AddAdminUser(model, imageString);
            if (createdUser != null)
            {
                return Ok(createdUser);
            }
            return BadRequest("Error occurs adding admin");
        }


        [HttpPost("add-moderator")]
        public async Task<ActionResult<RegisterDto>> CreateModeratorUser(RegisterDto model, IFormFile formFile)
        {
            var imageString = await _imageService.UploadImage(formFile);
            var createdUser = await _userService.AddModeratorUser(model, imageString);
            if (createdUser != null)
            {
                return Ok(createdUser);
            }
            return BadRequest("Error occurs adding moderator");
        }


        [HttpGet("get-users")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }


        [HttpPut("update-user/{id}")]
        public async Task<ActionResult<RegisterDto>> UpdateUser(string id, RegisterDto model, IFormFile formFile)
        {
            var imageString = await _imageService.UploadImage(formFile);

            var updatedUser = await _userService.UpdateUser(id, model, imageString);
            if (updatedUser != null)
            {
                return Ok(updatedUser);
            }
            return BadRequest("Error occurs updating user");
        }


        [HttpDelete("delete-user/{id}")]
        public async Task<ActionResult<bool>> DeleteUser(string id)
        {
            var result = await _userService.DeleteUser(id);
            return Ok(result);
        }


        [HttpPut("deactivate-user/{id}")]
        public async Task<ActionResult<bool>> DeactivateUser(string id)
        {
            var result = await _userService.DeactivateUser(id);
            return Ok(result);
        }


        [HttpGet("search-users")]
        public async Task<ActionResult<IEnumerable<UserDto>>> SearchUsers([FromQuery] string query)
        {
            var users = await _userService.SearchUsers(query);
            return Ok(users);
        }


        [HttpPost("add-user-to-role")]
        public async Task<ActionResult> AddUserToRole([FromBody] AddUserToRoleDto model)
        {
            await _userService.AddUserToRole(model.UserName, model.RoleName);
            return Ok();
        }


        [HttpGet("total-registered-users")]
        public async Task<ActionResult<long>> GetTotalRegisteredUsers()
        {
            var count = await _userService.GetTotalRegisteredUsers();
            return Ok(count);
        }
    }*/
}
