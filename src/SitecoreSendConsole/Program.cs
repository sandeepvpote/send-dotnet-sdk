using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SitecoreSendSDK;
using SitecoreSendSDK.Services;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace SitecoreSendConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SendClientSettingsConfiguration clientSettings = new SendClientSettingsConfiguration();

            var config = new ConfigurationBuilder()
                .AddJsonFile(@$"appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
            
            config.GetSection(SendClientSettingsConfiguration.SendClientSettings).Bind(clientSettings);


            IServiceCollection services = new ServiceCollection();
            services.AddOptions<SendClientSettingsConfiguration>()
                .Bind(config.GetSection(SendClientSettingsConfiguration.SendClientSettings))
                .ValidateDataAnnotations();
                

            services.AddSingleton(clientSettings);

            services.AddScoped<ISubscriberService, SubscriberService>();
            services.AddScoped<IMailingListService, IMailingListService>();
            services.AddTransient<SendApp>();
             

            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<SendApp>()?.Run();
        }
    }
}
