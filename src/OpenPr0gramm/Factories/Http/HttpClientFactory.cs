using System;
using System.Net.Http;
using OpenPr0gramm.Constants;

namespace OpenPr0gramm.Factories.Http
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
