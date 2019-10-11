using System.Collections.Generic;
using OpenPr0gramm.Models;

namespace OpenPr0gramm.Response
{
#if FW
    [Serializable]
#endif
    public class GetItemsInfoResponse : Pr0grammResponse
    {
        public IReadOnlyList<Tag> Tags { get; private set; }
        public IReadOnlyList<ItemComment> Comments { get; private set; }
    }
}
