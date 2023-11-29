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
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            var addSubscriberResponse = _subscriberService.AddSubscriber<SubscriberResponse, SubscriberRequest>("<<Enter mailing list id>>", new SubscriberRequest
            {
                Email = "sample@test.com"
            }, token).Result;

            var addSubscriberResponseJson = JsonSerializer.Serialize<SubscriberResponse>(addSubscriberResponse);
            Console.Write(addSubscriberResponseJson);

            var allSubscribersResponse = _subscriberService.GetAllSubscribers<SubscriberListResponse>("<<Enter mailing list id>>",
                SubscriberStatus.Subscribed.ToString(), ResponseFormat.json.ToString(), 1, 10, token).Result; 

            var allSubscriberJson = JsonSerializer.Serialize<SubscriberListResponse>(allSubscribersResponse);
            Console.Write(allSubscriberJson);


            Console.ReadLine();
        }
    }
}
