using System.Threading.Tasks;
using OpenPr0gramm.FormData;
using OpenPr0gramm.Response;
using Refit;

namespace OpenPr0gramm.ServiceInterfaces
{
    public interface IPr0grammCommentsService
    {
        [Post("/comments/delete")]
        Task<Pr0grammResponse> Delete([Body(BodySerializationMethod.UrlEncoded)]
            DeleteCommentData data);

        [Post("/comments/edit")]
        Task<Pr0grammResponse> Edit([Body(BodySerializationMethod.UrlEncoded)]
            EditCommentData data);

        [Post("/comments/post")]
        Task<Pr0grammResponse> Post([Body(BodySerializationMethod.UrlEncoded)]
            PostCommentData data);

        [Post("/comments/softDelete")]
        Task<Pr0grammResponse> SoftDelete([Body(BodySerializationMethod.UrlEncoded)]
            DeleteCommentData data);

        [Post("/comments/vote")]
        Task<Pr0grammResponse> Vote([Body(BodySerializationMethod.UrlEncoded)]
            VoteData data);
    }
}
