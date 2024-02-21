using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace FoodOrderingSystem.Services.SmsService
{
    public class TwilioSmsService
    {
        public TwilioSmsService()
        {

        }

        public async Task SendTextMessage()
        {
            string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Hi there",
                from: new Twilio.Types.PhoneNumber("+15017122661"),
                to: new Twilio.Types.PhoneNumber("+15558675310")
            );
        }
    }
}

