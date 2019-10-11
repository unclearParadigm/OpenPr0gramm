using System.Threading.Tasks;
using OpenPr0gramm.FormData;
using OpenPr0gramm.Response;
using Refit;

namespace OpenPr0gramm.ServiceInterfaces
{
    public interface IPr0grammPaypalService
    {
        [Post("/paypal/getcheckouturl")]
        Task<GetCheckoutUrlResponse> GetCheckoutUrl([Body(BodySerializationMethod.UrlEncoded)]
            PaymentData data);
    }
}
