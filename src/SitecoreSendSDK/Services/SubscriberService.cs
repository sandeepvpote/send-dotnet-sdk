using Flurl;
using Flurl.Http;

namespace SitecoreSendSDK.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly SendClientSettings _settings;

        public SubscriberService(SendClientSettings settings)
        {
            _settings = settings;
        }

        public Task<T> GetAllSubscriber<T>(string mailingListId, string status, string format, int pageNumber, int pageSize)
        {
            return _settings.PrepareRequest()
                .AppendPathSegment("lists")
                .AppendPathSegment(mailingListId)
                .AppendPathSegment("subscribers")
                .AppendPathSegment($"{status}.{format}")
                .SetQueryParam("Page", pageNumber)
                .SetQueryParam("PageSize", pageSize)
                .GetJsonAsync<T>();

        }

        public Task<T> GetSubscriberByEmailAddress<T>(string mailingListId, string format, string emailId)
        {
            return _settings.PrepareRequest()
                .AppendPathSegment("subscribers")
                .AppendPathSegment(mailingListId)
                .AppendPathSegment($"view.{format}")
                .SetQueryParam("Email", emailId)
                .GetJsonAsync<T>();

        }

        public Task<T1> AddSubscriber<T1, T2>(string mailingListId, T2 request)
        {
            var response= _settings.PrepareRequest()
                .AppendPathSegment("subscribers")
                .AppendPathSegment(mailingListId)
                .AppendPathSegment("subscribe.json")
                .PostJsonAsync(request)
                .ReceiveJson<T1>();

            return response;
        }

        public Task<T> GetSubscriberById<T>(string mailingListId, string subscriberId, string format)
        {
            var response = _settings.PrepareRequest()
                .AppendPathSegment("subscribers")
                .AppendPathSegment(mailingListId)
                .AppendPathSegment("find")
                .AppendPathSegment($"{subscriberId}.{format}")
                .GetJsonAsync<T>();

            return response;
        }
    }

    public static class ApiKeySettingsExtensions
    {
        public static IFlurlRequest PrepareRequest(this IApiKeySettings settings)
            => settings.Url.SetQueryParam("apikey", settings.ApiKey).WithHeader("Content-Type", "application/json");
    }
}
