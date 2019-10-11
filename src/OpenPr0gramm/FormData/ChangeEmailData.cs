using System.Diagnostics;
using Refit;

namespace OpenPr0gramm.FormData
{
    public class ChangeEmailData : PostFormData
    {
        [AliasAs("token")] public string Token { get; set; }

        public ChangeEmailData(string nonce, string token)
            : base(nonce)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(token));
            Token = token;
        }
    }
}
