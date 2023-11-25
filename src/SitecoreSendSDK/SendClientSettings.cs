using System.ComponentModel.DataAnnotations;

namespace SitecoreSendSDK
{
    public class SendClientSettings : IApiKeySettings
    {
        [Required]
        public string Url { get; init; }

        [Required]
        public string ApiKey { get; init; }
    }
}
