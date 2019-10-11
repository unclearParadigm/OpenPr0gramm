using System.Diagnostics;
using Refit;

namespace OpenPr0gramm.FormData
{
    public class SendPasswordResetMailData : AnonymousFormData
    {
        [AliasAs("email")] public string Email { get; }

        public SendPasswordResetMailData(string email)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(email));
            Email = email;
        }
    }
}
