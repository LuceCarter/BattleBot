using BattleBot;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using TwitchAgent.Services;

namespace TwitchAgent
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables()
              .AddUserSecrets<Program>()
              .AddCommandLine(args)
              .Build();

            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44393/ChatHub")
                .WithAutomaticReconnect()
                .Build();
                    

            IServiceCollection services = new ServiceCollection();

            TwitchSettings twitchSettings = new TwitchSettings
            {
                BotName = Configuration.GetValue<string>("TwitchSettings:BotName"),
                AuthToken = Configuration.GetValue<string>("TwitchSettings:AuthToken"),
                Channel = Configuration.GetValue<string>("TwitchSettings:Channel"),
                ChannelId = Configuration.GetValue<string>("TwitchSettings:ChannelId"),
                ClientId = Configuration.GetValue<string>("TwitchSettings:ClientId")
            };

            services.AddSingleton(twitchSettings);
            services.AddSingleton(connection);
            services.AddSingleton<TwitchChatService>();

            var serviceProvider = services.BuildServiceProvider();
            var twitchChatService = serviceProvider.GetService<TwitchChatService>();

            Console.ReadLine();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
