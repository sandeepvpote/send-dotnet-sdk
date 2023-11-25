using System.ComponentModel.DataAnnotations;

namespace SitecoreSendSDK
{
    public class SendClientSettingsConfiguration : IApiKeySettings
    {

        public const string SendClientSettings = "SendClientSettings";

        [Required]
        public string Url { get; init; }

        [Required]
        public string ApiKey { get; init; }
    }
}
