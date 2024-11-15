using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace SitecoreSendSDK.Services;
internal class MailingListService : IMailingListService
{
    private readonly SendClientSettingsConfiguration _settings;

    public MailingListService(IOptions<SendClientSettingsConfiguration> settings)
    {
        _settings = settings.Value;
    }
    public Task<T> GetAllActiveMailingList<T>(string format, bool withStatistics , string shortBy , string sortMethod,
        CancellationToken cancellationToken)
    {
        return _settings.PrepareRequest()
            .AppendPathSegment($"lists.{format}")
            .SetQueryParam("WithStatistics", withStatistics)
            .SetQueryParam("ShortBy", shortBy)
            .SetQueryParam("SortMethod", sortMethod)
            .GetJsonAsync<T>(cancellationToken);
    }

    public Task<T> GetMailingListDetails<T>(string mailingListID, string format, bool withStatistics,
        CancellationToken cancellationToken)
    {
        return _settings.PrepareRequest()
            .AppendPathSegment(mailingListID)
            .AppendPathSegment($"details.{format}")
            .SetQueryParam("WithStatistics", withStatistics)
            .GetJsonAsync<T>(cancellationToken);
    }

    public Task<T> GetAllActiveMailingListWithPaging<T>(int page, int pageSize, string format, string shortBy, string sortMethod,
        CancellationToken cancellationToken)
    {
        return _settings.PrepareRequest()
            .AppendPathSegment("lists")
            .AppendPathSegment(page)
            .AppendPathSegment($"{pageSize}.{format}")
            .SetQueryParam("ShortBy", shortBy)
            .SetQueryParam("SortMethod", sortMethod)
            .GetJsonAsync<T>(cancellationToken);
    }
}
