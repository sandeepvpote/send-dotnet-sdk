using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreSendSDK.Services;
public interface IMailingListService
{
    Task<T> GetAllActiveMailingList<T>(string format, bool withStatistics , string shortBy, string sortMethod,
        CancellationToken cancellationToken);

    Task<T> GetMailingListDetails<T>(string mailingListID, string format, bool withStatistics,
        CancellationToken cancellationToken);

    Task<T> GetAllActiveMailingListWithPaging<T>(int page, int pageSize, string format,  string shortBy, string sortMethod,
        CancellationToken cancellationToken);
}
