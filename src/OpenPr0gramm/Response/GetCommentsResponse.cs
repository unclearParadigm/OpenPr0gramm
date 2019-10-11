using System.Collections.Generic;
using OpenPr0gramm.Models;

namespace OpenPr0gramm.Response
{
#if FW
    [Serializable]
#endif
    public class GetCommentsResponse : Pr0grammResponse
    {
        public IReadOnlyList<ProfileComment> Comments { get; private set; }
        public bool HasOlder { get; private set; }
        public bool HasNewer { get; private set; }
        public CommentUser User { get; private set; }
    }
}
