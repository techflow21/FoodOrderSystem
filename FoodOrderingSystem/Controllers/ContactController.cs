using FoodOrderingSystem.Core.DTOs;
using FoodOrderingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FoodOrderingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/contact")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpPost("submit-contact-form")]
        public async Task<IActionResult> SubmitContactForm([FromBody] ContactRequestDto request)
        {
            try
            {
                await _contactService.SubmitContactForm(request);
                return Ok("Contact form submitted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
