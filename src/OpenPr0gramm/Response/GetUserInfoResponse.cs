using System.Collections.Generic;
using Newtonsoft.Json;
using OpenPr0gramm.Models;

namespace OpenPr0gramm.Response
{
#if FW
    [Serializable]
#endif
    public class GetUserInfoResponse : Pr0grammResponse
    {
        public AccountInfo Account { get; private set; }

        [JsonProperty(PropertyName = "invited")]
        public IReadOnlyList<InvitedUser> InvitedUsers { get; private set; }
    }
}
