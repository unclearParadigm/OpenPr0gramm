using System.Threading.Tasks;
using OpenPr0gramm.FormData;
using OpenPr0gramm.Models;
using OpenPr0gramm.Response;
using Refit;

namespace OpenPr0gramm.ServiceInterfaces
{
    public interface IPr0grammInboxService
    {
        [Get("/inbox/all")]
        Task<GetMessagesResponse<InboxItem>> GetAll();

        [Get("/inbox/messages")]
        Task<GetMessagesResponse<PrivateMessage>> GetPrivateMessages();

        [Post("/inbox/post")]
        Task<Pr0grammResponse> PostMessage([Body(BodySerializationMethod.UrlEncoded)]
            PrivateMessageData data);

        [Get("/inbox/unread")]
        Task<GetMessagesResponse<InboxItem>> GetUnreadMessages();
    }
}
