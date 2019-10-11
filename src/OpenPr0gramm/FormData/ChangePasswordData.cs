using System.Diagnostics;
using Refit;

namespace OpenPr0gramm.FormData
{
    public class ChangePasswordData : ChangeAccountSettingData
    {
        [AliasAs("password")] public string NewPassword { get; }

        public ChangePasswordData(string nonce, string currentPassword, string newPassword) : base(nonce,
            currentPassword)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(newPassword));
            Debug.Assert(newPassword.Length >= 6);
            NewPassword = newPassword;
        }
    }
}
