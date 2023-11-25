using SitecoreSendSDK.Services;
using System.Text.Json;
using SitecoreSendConsole.Models;

namespace SitecoreSendConsole
{
    internal class SendApp
    {
        private readonly ISubscriberService _subscriberService;

        public SendApp(ISubscriberService subscriberService)
        {
            _subscriberService=subscriberService;
        }

        public void Run()
        {
            var addSubscriberResponse = _subscriberService.AddSubscriber<SubscriberResponse, SubscriberRequest>("", new SubscriberRequest
            {
                Email = "testsendsdk5@test.com"
            }).Result;

            var addSubscriberResponseJson = JsonSerializer.Serialize<SubscriberResponse>(addSubscriberResponse);
            Console.Write(addSubscriberResponseJson);

            var allSubscribersResponse = _subscriberService.GetAllSubscriber<SubscriberListResponse>("",
                SubscriberStatus.Subscribed.ToString(), ResponseFormat.json.ToString(), 1, 10).Result; 

            var allSubscriberJson = JsonSerializer.Serialize<SubscriberListResponse>(allSubscribersResponse);
            Console.Write(allSubscriberJson);

            var getSubscriberByEmail = _subscriberService.
                GetSubscriberByEmailAddress<SubscriberResponse>("", 
                    ResponseFormat.json.ToString(), "testsendsdk2@test.com").Result;

            var getSubscriberByEmailJson = JsonSerializer.Serialize<SubscriberResponse>(getSubscriberByEmail);

            Console.Write(getSubscriberByEmailJson);

            Console.ReadLine();
        }
    }
}
