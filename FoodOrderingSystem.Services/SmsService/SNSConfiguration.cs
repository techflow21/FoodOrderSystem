using Amazon;

namespace FoodOrderingSystem.Services.SmsService
{
    public class SNSConfiguration
    {
        public string AwsKeyId { get; set; }
        public string AwsKeySecret { get; set; }
        public RegionEndpoint RegionEndpoint { get; set; }
    }
}
