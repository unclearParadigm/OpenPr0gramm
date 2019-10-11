using System.Net;
using System.Net.Http;

namespace OpenPr0gramm.Infrastructure
{
    public class HttpClientHandlerFactory
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
