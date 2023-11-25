namespace SitecoreSendConsole.Models
{
    public class SubscriberResponse
    {
        public int Code { get; set; }
        public object Error { get; set; }
        public SubscribeContext Context { get; set; }

        public bool Success { get; set; }
    }
    public class SubscribeContext
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public object UnsubscribedOn { get; set; }
        public object UnsubscribedFromID { get; set; }
        public int SubscribeType { get; set; }
        public int SubscribeMethod { get; set; }
        public List<CustomField> CustomFields { get; set; }
        public object RemovedOn { get; set; }
        public List<string> Tags { get; set; }
    }

    public class CustomField
    {
        public string CustomFieldID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
