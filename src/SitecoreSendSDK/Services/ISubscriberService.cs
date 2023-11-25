namespace SitecoreSendSDK.Services
{
    public interface ISubscriberService
    {
        Task<T1> AddSubscriber<T1, T2>(string mailingListId, T2 request, CancellationToken cancellationToken);

        Task<T> GetAllSubscriber<T>(string mailingListId, string status, string format, int pageNumber, int pageSize,
            CancellationToken cancellationToken);

        Task<T> GetSubscriberByEmailAddress<T>(string mailingListId, string format, string emailId,
            CancellationToken cancellationToken);

        Task<T> GetSubscriberById<T>(string mailingListId, string subscriberId, string format,
            CancellationToken cancellationToken);
    }
}
