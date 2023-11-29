namespace SitecoreSendSDK.Services
{
    public interface ISubscriberService
    {
        Task<T> GetAllSubscribers<T>(string mailingListId, string status, string format, int pageNumber, int pageSize,
            CancellationToken cancellationToken);

        Task<T> GetSubscriberByEmailAddress<T>(string mailingListId, string format, string emailId,
            CancellationToken cancellationToken);

        Task<T> GetSubscriberById<T>(string mailingListId, string subscriberId, string format,
            CancellationToken cancellationToken);

        Task<T1> AddSubscriber<T1, T2>(string mailingListId, T2 request, CancellationToken cancellationToken);

        Task<T1> UpdateSubscriber<T1, T2>(string mailingListId,
            string subscriberId,
            string format,
            T2 request,
            CancellationToken cancellationToken);

        Task<T1> UnSubscribeAll<T1, T2>(
            string format,
            T2 request,
            CancellationToken cancellationToken);

        Task<T1> UnSubscribe<T1, T2>(string mailingListId,
            string format,
            T2 request,
            CancellationToken cancellationToken);

        Task<T1> CampaignUnSubscribe<T1, T2>(string mailingListId, string campaignId,
            string subscriberId,
            string format,
            T2 request,
            CancellationToken cancellationToken);

        Task<T1> RemoveSubscriber<T1, T2>(string mailingListId,
            string format,
            T2 request,
            CancellationToken cancellationToken);

        Task<T1> RemoveSubscribers<T1, T2>(string mailingListId,
            string format,
            T2 request,
            CancellationToken cancellationToken);

    }
}
