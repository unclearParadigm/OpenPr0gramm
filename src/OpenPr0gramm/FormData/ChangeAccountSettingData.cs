using System.Diagnostics;
using Refit;

namespace OpenPr0gramm.FormData
{
    public class ChangeAccountSettingData : PostFormData
    {
        [AliasAs("currentPassword")] public string CurrentPassword { get; }

        public ChangeAccountSettingData(string nonce, string currentPassword)
            : base(nonce)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(currentPassword));
            CurrentPassword = currentPassword;
        }
    }
}
