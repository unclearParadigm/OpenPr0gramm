using System.Collections.Generic;
using OpenPr0gramm.Models;

namespace OpenPr0gramm.Response
{
#if FW
    [Serializable]
#endif
    public class GetFollowListResponse : Pr0grammResponse
    {
        public IReadOnlyList<FollowedUser> List { get; private set; }
    }
}
