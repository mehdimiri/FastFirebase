using FastFirebase.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace FastFirebase.Example.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello FastFirebase!");

            Task.Run(() => SendPushNoty());

            System.Console.ReadLine();

        }

        private static async Task SendPushNoty()
        {
            var serviceProvider = GetServiceProvider();
            var pushService = serviceProvider.GetRequiredService<IPushService>();

            var pushJsonModel = new PushJsonModel
            {
                deviceTokens = new string[] { "DeviceToken1", "DeviceToken2" },
                title = "test",
                body = "this is a test",
                data = null
            };
            await pushService.SendPushAsync(pushJsonModel);


            var channelJsonModel = new ChannelJsonModel
            {
                channelName = "channelName",
                subTitle = "test",
                title = "test",
                body = "this is a test"
            };
            await pushService.SendChannelAsync(channelJsonModel);
        }

        private static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddOptions();

            services.AddFirebase(options =>
            {
                options.ServerKey = "FIREBASE_SERVER_KEY";
            });

            return services.BuildServiceProvider();
        }
    }
}
