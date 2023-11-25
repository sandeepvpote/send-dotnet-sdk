using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SitecoreSendSDK;
using SitecoreSendSDK.Services;

namespace SitecoreSendConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            SendClientSettings clientSettings = new SendClientSettings();
            var config = new ConfigurationBuilder()
                .AddJsonFile(@$"appsettings.json", optional: false, reloadOnChange: true).Build();
            
            config.GetSection("SendClientSettings").Bind(clientSettings);


            IServiceCollection services = new ServiceCollection();

            services.AddSingleton(clientSettings);

            services.AddScoped<ISubscriberService, SubscriberService>();
             services.AddTransient<SendApp>();

            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<SendApp>()?.Run();
        }

       
    }
}
