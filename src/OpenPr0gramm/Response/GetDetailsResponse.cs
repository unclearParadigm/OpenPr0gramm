using System.Collections.Generic;
using OpenPr0gramm.Models;

namespace OpenPr0gramm.Response
{
#if FW
    [Serializable]
#endif
    public class GetDetailsResponse : Pr0grammResponse
    {
        public IReadOnlyList<ItemTagDetails> Tags { get; private set; }
    }
}
