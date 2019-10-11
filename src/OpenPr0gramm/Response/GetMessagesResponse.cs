using System.Collections.Generic;

namespace OpenPr0gramm.Response
{
#if FW
    [Serializable]
#endif
    public class GetMessagesResponse<T> : Pr0grammResponse
    {
        public IReadOnlyList<T> Messages { get; private set; }
        public bool HasOlder { get; private set; }
        public bool HasNewer { get; private set; }
    }
}
