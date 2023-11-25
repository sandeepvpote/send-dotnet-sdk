namespace SitecoreSendConsole.Models
{
    public class SubscriberRequest
    {
        public string Email { get; init; }


        public class UpdateSubscriberRequest
        {
            public string SubscriberId { get; init; }
            public string Email { get; init; }
        }
    }
}
