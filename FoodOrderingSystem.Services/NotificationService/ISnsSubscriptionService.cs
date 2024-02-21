namespace FoodOrderingSystem.Services.NotificationService
{
    public interface ISnsSubscriptionService
    {
        void CreateTopic(string topicName);
        void DeleteTopic(string topicArn);
        void ListTopics();
        void SubscribeSmsPhoneNumber(string topicArn, string phoneNumber);
        void SubscribeEmailAddressToTopic(string topicArn, string emailAddress);
        void PublishToSubscribers(string topicArn, string message);
        void SendSmsToSubscribers(string topicArn, string message);
    }
}
