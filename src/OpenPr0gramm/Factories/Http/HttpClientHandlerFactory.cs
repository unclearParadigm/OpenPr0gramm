using System.Net;
using System.Net.Http;

namespace OpenPr0gramm.Factories.Http
{
    public static class HttpClientHandlerFactory
    {
        public static HttpClientHandler Create(IWebProxy proxy = null)
        {
            return new HttpClientHandler
            {
                UseCookies = true,
                AllowAutoRedirect = false,
                CheckCertificateRevocationList = false,

                Proxy = proxy,
                UseProxy = proxy != null
            };
        }
    }
}
