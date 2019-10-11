using System.Collections.Generic;
using OpenPr0gramm.Models;

namespace OpenPr0gramm.Response
{
#if FW
    [Serializable]
#endif
    public class GetItemsResponse : Pr0grammResponse
    {
        public bool AtEnd { get; private set; }
        public bool AtStart { get; private set; }
        public object Error { get; private set; }
        public IReadOnlyList<Item> Items { get; private set; }
    }
}
