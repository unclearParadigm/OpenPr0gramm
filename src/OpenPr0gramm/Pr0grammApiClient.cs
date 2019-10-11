using OpenPr0gramm.Json;
using Refit;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Serialization;
using OpenPr0gramm.Constants;
using OpenPr0gramm.Factories.Http;
using OpenPr0gramm.ServiceInterfaces;

namespace OpenPr0gramm
{
    public interface IPr0grammApiClient : IDisposable
    {
        IPr0grammUserService User { get; }
        IPr0grammTagsService Tags { get; }
        IPr0grammProfileService Profile { get; }
        IPr0grammItemsService Items { get; }
        IPr0grammInboxService Inbox { get; }
        IPr0grammCommentsService Comments { get; }
        IPr0grammPaypalService Paypal { get; }
        IPr0grammContactService Contact { get; }
        IPr0grammBitcoinService Bitcoin { get; }

        CookieContainer GetCookies();
        string GetCurrentNonce();
        string GetCurrentSessionId();
    }

    public class Pr0grammApiClient : IPr0grammApiClient
    {
        private readonly HttpClient _client;
        private readonly HttpClientHandler _handler;

        public IPr0grammUserService User { get; private set; }
        public IPr0grammTagsService Tags { get; private set; }
        public IPr0grammProfileService Profile { get; private set; }
        public IPr0grammItemsService Items { get; private set; }
        public IPr0grammInboxService Inbox { get; private set; }
        public IPr0grammCommentsService Comments { get; private set; }
        public IPr0grammPaypalService Paypal { get; private set; }
        public IPr0grammContactService Contact { get; private set; }
        public IPr0grammBitcoinService Bitcoin { get; private set; }

        private static readonly RefitSettings _refitSettings = new RefitSettings
        {
            UrlParameterFormatter = new EnumsAsIntegersParameterFormatter(),
            JsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
            }
        };

        public Pr0grammApiClient(IWebProxy proxy = null)
        {
            _handler = HttpClientHandlerFactory.Create(proxy);
            _client = HttpClientFactory.Create(_handler, nameof(Pr0grammApiClient));
            InitializeRestServices();
        }

        public Pr0grammApiClient(CookieContainer cookieContainer, IWebProxy proxy = null)
        {
            _handler = HttpClientHandlerFactory.Create(proxy);
            _handler.CookieContainer = cookieContainer;
            _client = HttpClientFactory.Create(_handler, nameof(Pr0grammApiClient));
            InitializeRestServices();
        }

        private void InitializeRestServices()
        {
            User = RestService.For<IPr0grammUserService>(_client, _refitSettings); // Done
            Tags = RestService.For<IPr0grammTagsService>(_client, _refitSettings); // Done
            Profile = RestService.For<IPr0grammProfileService>(_client, _refitSettings); // Done
            Items = RestService.For<IPr0grammItemsService>(_client, _refitSettings); // Done
            Inbox = RestService.For<IPr0grammInboxService>(_client, _refitSettings); // Done
            Comments = RestService.For<IPr0grammCommentsService>(_client, _refitSettings); // Done
            Paypal = RestService.For<IPr0grammPaypalService>(_client, _refitSettings); // Done
            Contact = RestService.For<IPr0grammContactService>(_client, _refitSettings); // Done
            Bitcoin = RestService.For<IPr0grammBitcoinService>(_client, _refitSettings); // Done
        }

        public CookieContainer GetCookies() => _handler?.CookieContainer;

        public string GetCurrentNonce()
        {
            var sessionId = GetCurrentSessionId();
            return sessionId?.Substring(0, 16);
        }

        public string GetCurrentSessionId()
        {
            var container = _handler?.CookieContainer;
            if (container == null)
                return null;
            var cookies =
                container.GetCookies(new Uri(ClientConstants.ProtocolPrefix + ClientConstants.HostName + "/"));
            var meCookie = cookies["me"]?.Value;
            if (meCookie == null)
                return null;
            meCookie = WebUtility.UrlDecode(meCookie);
            var cookie = JsonConvert.DeserializeObject<Pr0grammMeCookie>(meCookie);
            return cookie?.Id;
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _handler.Dispose();
                    _client.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }

    internal class Pr0grammMeCookie
    {
        public string N { get; set; }
        public string Id { get; set; }
        public bool A { get; set; }
        public string pp { get; set; }
        public bool Paid { get; set; }
    }
}
