using System.Diagnostics;
using Refit;

namespace OpenPr0gramm.FormData
{
    public class InviteData : PostFormData
    {
        [AliasAs("email")] public string Email { get; }

        public InviteData(string nonce, string email)
            : base(nonce)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(email));
            Email = email;
        }
    }
}
