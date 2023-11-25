using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;

namespace SitecoreSendSDK.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly SendClientSettingsConfiguration _settings;

        public SubscriberService(IOptions<SendClientSettingsConfiguration> settings)
        {
            _settings = settings.Value;
        }

        public Task<T> GetAllSubscriber<T>(string mailingListId, string status, string format, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return _settings.PrepareRequest()
                .AppendPathSegment("lists")
                .AppendPathSegment(mailingListId)
                .AppendPathSegment("subscribers")
                .AppendPathSegment($"{status}.{format}")
                .SetQueryParam("Page", pageNumber)
                .SetQueryParam("PageSize", pageSize)
                .GetJsonAsync<T>(cancellationToken);

        }

        public Task<T> GetSubscriberByEmailAddress<T>(string mailingListId, string format, string emailId, CancellationToken cancellationToken)
        {
            return _settings.PrepareRequest()
                .AppendPathSegment("subscribers")
                .AppendPathSegment(mailingListId)
                .AppendPathSegment($"view.{format}")
                .SetQueryParam("Email", emailId)
                .GetJsonAsync<T>(cancellationToken);

        }

        public Task<T1> AddSubscriber<T1, T2>(string mailingListId, T2 request, CancellationToken cancellationToken)
        {
            var response= _settings.PrepareRequest()
                .AppendPathSegment("subscribers")
                .AppendPathSegment(mailingListId)
                .AppendPathSegment("subscribe.json")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<T1>();

            return response;
        }

        public Task<T1> UpdateSubscriber<T1, T2>(string mailingListId, 
            string subscriberId, 
            string format, 
            T2 request, 
            CancellationToken cancellationToken)
        {
            var response = _settings.PrepareRequest()
                .AppendPathSegment("subscribers")
                .AppendPathSegment(mailingListId)
                .AppendPathSegment("update")
                .AppendPathSegment($"{subscriberId}.{format}")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<T1>();

            return response;
        }

        public Task<T> GetSubscriberById<T>(string mailingListId, string subscriberId, string format, CancellationToken cancellationToken)
        {
            var response = _settings.PrepareRequest()
                .AppendPathSegment("subscribers")
                .AppendPathSegment(mailingListId)
                .AppendPathSegment("find")
                .AppendPathSegment($"{subscriberId}.{format}")
                .GetJsonAsync<T>(cancellationToken);

            return response;
        }
    }

    public static class ApiKeySettingsExtensions
    {
        public static IFlurlRequest PrepareRequest(this IApiKeySettings settings)
            => settings.Url.SetQueryParam("apikey", settings.ApiKey).WithHeader("Content-Type", "application/json");
    }
}
