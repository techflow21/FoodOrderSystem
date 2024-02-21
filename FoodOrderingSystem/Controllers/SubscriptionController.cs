using FoodOrderingSystem.Services.NotificationService;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SnsSubscriptionController : ControllerBase
    {
        //private readonly LoggerManager _logger;
        private readonly ISnsSubscriptionService _snsService;

        public SnsSubscriptionController(SnsSubscriptionService snsService)
        {
            //_logger = logger;
            _snsService = snsService;
        }


        [HttpPost("CreateTopic")]
        public IActionResult CreateTopic(string topicName)
        {
            //_logger.LogInfo("API Request: CreateTopic");
            _snsService.CreateTopic(topicName);
            return Ok();
        }


        [HttpPost("DeleteTopic")]
        public IActionResult DeleteTopic(string topicArn)
        {
            //_logger.LogInfo("API Request: DeleteTopic");
            _snsService.DeleteTopic(topicArn);
            return Ok();
        }


        [HttpGet("ListTopics")]
        public IActionResult ListTopics()
        {
            //_logger.LogInfo("API Request: ListTopics");
            _snsService.ListTopics();
            return Ok();
        }


        [HttpPost("SubscribeSmsPhoneNumber")]
        public IActionResult SubscribeSmsPhoneNumber(string topicArn, string phoneNumber)
        {
            //_logger.LogInfo("API Request: SubscribeSmsPhoneNumber");
            _snsService.SubscribeSmsPhoneNumber(topicArn, phoneNumber);
            return Ok();
        }


        [HttpPost("SubscribeEmailAddressToTopic")]
        public IActionResult SubscribeEmailAddressToTopic(string topicArn, string emailAddress)
        {
            //_logger.LogInfo("API Request: SubscribeEmailAddressToTopic");
            _snsService.SubscribeEmailAddressToTopic(topicArn, emailAddress);
            return Ok();
        }


        [HttpPost("PublishToSubscribers")]
        public IActionResult PublishToSubscribers(string topicArn, string message)
        {
            //_logger.LogInfo("API Request: PublishToSubscribers");
            _snsService.PublishToSubscribers(topicArn, message);
            return Ok();
        }


        [HttpPost("SendSmsToSubscribers")]
        public IActionResult SendSmsToSubscribers(string topicArn, string message)
        {
            //_logger.LogInfo("API Request: SendSmsToSubscribers");
            _snsService.SendSmsToSubscribers(topicArn, message);
            return Ok();
        }
    }


    /*[ApiController]
    [Route("api/subscription")]
    public class SubscriptionController : ControllerBase
    {
        IAwsSubscriptionService _subscriptionService;
        public SubscriptionController(IAwsSubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }


        [HttpPost("send-subscription-email")]
        public async Task<IActionResult> SendSubscriptionEmail([FromBody] string message)
        {
            await _subscriptionService.SendSubscriptionEmailAsync(message);
            return Ok("Email sent to all subscribed users");
        }


        [HttpPost("subscribe-user")]
        public async Task<IActionResult> SubscribeUser([FromBody] string emailAddress)
        {
            await _subscriptionService.SubscribeUserAsync(emailAddress);
            return Ok("User subscription successful.");
        }


        [HttpPost("unsubscribe-user")]
        public async Task<IActionResult> UnsubscribeUser(string emailAddress)
        {
            try
            {
                await _subscriptionService.UnsubscribeUserAsync(emailAddress);
                return Ok("User unsubscribed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to unsubscribe user.");
            }
        }


        [HttpGet("get-subscribed-users")]
        public async Task<ActionResult<List<string>>> GetSubscribedUsers()
        {
            var subscribedUsers = await _subscriptionService.GetSubscribedUsersAsync();
            return Ok(subscribedUsers);
        }
    }*/
}
