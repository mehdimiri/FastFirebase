using FastFirebase.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FastFirebase
{
    public class PushService : IPushService
    {

        private readonly PushOptions _options;
        private const string _fireBaseApi = "https://fcm.googleapis.com/fcm/send";
        public PushService(IOptions<PushOptions> options)
        {
            _options = options != null ? options.Value : throw new ArgumentNullException(nameof(options));

        }

        public async Task SendPushAsync(PushJsonModel pushJsonModel)
        {
            var messageInformation = new 
            {
                notification = new 
                {
                    title = pushJsonModel.title,
                    text = pushJsonModel.body
                },
                data = pushJsonModel.data,
                registration_ids = pushJsonModel.deviceTokens
            };
            string jsonMessage = JsonConvert.SerializeObject(messageInformation);
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, _fireBaseApi);
                request.Headers.TryAddWithoutValidation("Authorization", $"key={ _options.ServerKey}");
                request.Content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");
                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task SendChannelAsync(ChannelJsonModel channelJsonModel)
        {
            var messageInformation = new
            {
                to = $"/topics/{channelJsonModel.channelName}",
                priority = "high",
                notification = new
                {
                    body = channelJsonModel.body,
                    title = channelJsonModel.title,
                    priority = "high",
                    content_available = true,
                    subtitle = channelJsonModel.subTitle
                }
            };

            string jsonMessage = JsonConvert.SerializeObject(messageInformation);
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, _fireBaseApi);
                request.Headers.TryAddWithoutValidation("Authorization", $"key={_options.ServerKey}");
                request.Content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
