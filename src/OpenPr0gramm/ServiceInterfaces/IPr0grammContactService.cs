using System.Threading.Tasks;
using OpenPr0gramm.FormData;
using OpenPr0gramm.Response;
using Refit;

namespace OpenPr0gramm.ServiceInterfaces
{
    public interface IPr0grammContactService
    {
        [Post("/contact/send")]
        Task<Pr0grammResponse> Send([Body(BodySerializationMethod.UrlEncoded)]
            ContactData data);
    }
}
