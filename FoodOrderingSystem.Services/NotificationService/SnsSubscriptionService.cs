using Amazon.SimpleNotificationService.Model;
using Amazon.SimpleNotificationService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FoodOrderingSystem.Services.NotificationService
{
    public class SnsSubscriptionService : ISnsSubscriptionService
    {
        private readonly ILogger<SnsSubscriptionService> _logger;
        private readonly IAmazonSimpleNotificationService _snsClient;

        public SnsSubscriptionService(ILogger<SnsSubscriptionService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _snsClient = new AmazonSimpleNotificationServiceClient(
                configuration["AWS:AccessKeyId"],
                configuration["AWS:SecretAccessKey"],
                Amazon.RegionEndpoint.GetBySystemName(configuration["AWS:Region"])
            );
        }

        public void CreateTopic(string topicName)
        {
            _logger.LogInformation($"Creating SNS topic: {topicName}");

            var createTopicRequest = new CreateTopicRequest
            {
                Name = topicName
            };

            var createTopicResponse = _snsClient.CreateTopicAsync(createTopicRequest).Result;
            var topicArn = createTopicResponse.TopicArn;
            _logger.LogInformation($"Topic created with ARN: {topicArn}");
        }


        public void DeleteTopic(string topicArn)
        {
            _logger.LogInformation($"Deleting SNS topic: {topicArn}");

            var deleteTopicRequest = new DeleteTopicRequest
            {
                TopicArn = topicArn
            };
            _snsClient.DeleteTopicAsync(deleteTopicRequest).Wait();
            _logger.LogInformation($"Topic deleted: {topicArn}");
        }


        public void ListTopics()
        {
            _logger.LogInformation("Listing SNS topics");

            var listTopicsResponse = _snsClient.ListTopicsAsync().Result;
            foreach (var topic in listTopicsResponse.Topics)
            {
                _logger.LogInformation($"Topic ARN: {topic.TopicArn}");
            }
        }


        public void SubscribeSmsPhoneNumber(string topicArn, string phoneNumber)
        {
            _logger.LogInformation($"Subscribing SMS phone number: {phoneNumber} to topic: {topicArn}");

            var subscribeRequest = new SubscribeRequest
            {
                TopicArn = topicArn,
                Protocol = "sms",
                Endpoint = phoneNumber
            };
            _snsClient.SubscribeAsync(subscribeRequest).Wait();
            _logger.LogInformation($"Subscribed SMS phone number: {phoneNumber} to topic: {topicArn}");
        }


        public void SubscribeEmailAddressToTopic(string topicArn, string emailAddress)
        {
            _logger.LogInformation($"Subscribing email address: {emailAddress} to topic: {topicArn}");

            var subscribeRequest = new SubscribeRequest
            {
                TopicArn = topicArn,
                Protocol = "email",
                Endpoint = emailAddress
            };
            _snsClient.SubscribeAsync(subscribeRequest).Wait();
            _logger.LogInformation($"Subscribed email address: {emailAddress} to topic: {topicArn}");
        }


        public void PublishToSubscribers(string topicArn, string message)
        {
            _logger.LogInformation($"Publishing message to topic: {topicArn}");

            var publishRequest = new PublishRequest
            {
                TopicArn = topicArn,
                Message = message
            };
            var publishResponse = _snsClient.PublishAsync(publishRequest).Result;
            _logger.LogInformation($"Message published with ID: {publishResponse.MessageId}");
        }


        public void SendSmsToSubscribers(string topicArn, string message)
        {
            _logger.LogInformation($"Sending SMS to topic: {topicArn}");

            var publishRequest = new PublishRequest
            {
                TopicArn = topicArn,
                Message = message
            };
            var publishResponse = _snsClient.PublishAsync(publishRequest).Result;
            _logger.LogInformation($"SMS sent with message ID: {publishResponse.MessageId}");
        }
    }
}
