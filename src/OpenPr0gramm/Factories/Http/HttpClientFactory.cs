using System;
using System.Net.Http;

namespace OpenPr0gramm.Infrastructure
{
    public class HttpClientFactory
    {
        public static HttpClient Create(HttpClientHandler clientHandler, string componentName)
        {
            var client = new HttpClient(clientHandler)
            {
                Timeout = TimeSpan.FromSeconds(30),
                BaseAddress = new Uri(ClientConstants.ApiBaseUrl)
            };

            client.DefaultRequestHeaders.UserAgent.ParseAdd(ClientConstants.GetUserAgent(componentName));

            return client;
        }
    }
}
