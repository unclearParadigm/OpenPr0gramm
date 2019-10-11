using OpenPr0gramm.Models;

namespace OpenPr0gramm.Response
{
#if FW
    [Serializable]
#endif
    public class LoadInviteResponse : Pr0grammResponse
    {
        public InvitingUser Inviter { get; private set; }
        public string Email { get; private set; }
    }
}
