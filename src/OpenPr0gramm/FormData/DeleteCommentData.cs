using Refit;

namespace OpenPr0gramm.FormData
{
    public class DeleteCommentData : PostFormData
    {
        [AliasAs("id")] public int CommentId { get; }
        [AliasAs("reason")] public string Reason { get; }

        public DeleteCommentData(string nonce, int commentId, string reason)
            : base(nonce)
        {
            CommentId = commentId;
            Reason = reason;
        }
    }
}
