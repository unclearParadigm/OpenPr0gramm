using System.Threading.Tasks;
using OpenPr0gramm.FormData;
using OpenPr0gramm.Response;
using Refit;

namespace OpenPr0gramm.ServiceInterfaces
{
    public interface IPr0grammBitcoinService
    {
        [Post("/bitcoin/getpaymentaddress")]
        Task<GetPaymentAddressResponse> GetPaymentAddress([Body(BodySerializationMethod.UrlEncoded)]
            PaymentData data);
    }
}
