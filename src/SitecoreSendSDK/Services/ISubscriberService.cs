namespace SitecoreSendSDK.Services
{
    public interface ISubscriberService
    {
        //Task<SubscriberResponse> AddSubscriber(string mailingListId, SubscriberRequest request);
        //Task<T> AddSubscriber<T>(string mailingListId, T request);
        Task<T1> AddSubscriber<T1, T2>(string mailingListId, T2 request);

        //Task<SubscriberListResponse> GetAllSubscriber(string mailingListId, string status, string format,int pageNumber, int pageSize);

        Task<T> GetAllSubscriber<T>(string mailingListId, string status, string format, int pageNumber, int pageSize);

        //Task<SubscriberResponse> GetSubscriberByEmailAddress(string mailingListId, string format, string emailId);

        Task<T> GetSubscriberByEmailAddress<T>(string mailingListId, string format, string emailId);
    }
}
