using System.Diagnostics;
using Refit;

namespace OpenPr0gramm.FormData
{
    public class TokenActionData : PostFormData
    {
        [AliasAs("token")] public string Token { get; }

        public TokenActionData(string nonce, string token)
            : base(nonce)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(token));
            Token = token;
        }
    }
}
