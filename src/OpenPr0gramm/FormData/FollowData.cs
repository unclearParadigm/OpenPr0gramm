using System.Diagnostics;
using Refit;

namespace OpenPr0gramm.FormData
{
    public class FollowData : PostFormData
    {
        [AliasAs("name")] public string Name { get; }

        public FollowData(string nonce, string name)
            : base(nonce)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(name));
            Name = name;
        }
    }
}
