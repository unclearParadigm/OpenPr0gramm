using System.Diagnostics;
using Refit;

namespace OpenPr0gramm.FormData
{
    public class RequestEmailChangeData : ChangeAccountSettingData
    {
        [AliasAs("email")] public string NewEmail { get; }

        public RequestEmailChangeData(string nonce, string currentPassword, string newEmail) : base(nonce,
            currentPassword)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(newEmail));
            NewEmail = newEmail;
        }
    }
}
