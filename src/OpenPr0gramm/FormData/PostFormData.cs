using System.Diagnostics;
using Refit;

namespace OpenPr0gramm.FormData
{
    public abstract class PostFormData
    {
        [AliasAs("_nonce")] public string Nonce { get; }

        protected PostFormData(string nonce)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(nonce));
            Debug.Assert(nonce.Length == 16);
            Nonce = nonce;
        }
    }

    public abstract class AnonymousFormData
    {
        // No Nonce
    }
}
