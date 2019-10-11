using System.Diagnostics;
using Refit;

namespace OpenPr0gramm.FormData
{
    public class LogOutData : PostFormData
    {
        [AliasAs("id")] public string SessionId { get; }

        public LogOutData(string nonce, string sessionId)
            : base(nonce)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(sessionId));
            Debug.Assert(sessionId.Length == 32);
            SessionId = sessionId;
        }
    }
}
