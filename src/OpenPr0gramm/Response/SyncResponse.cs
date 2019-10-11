using System.Collections.Generic;

namespace OpenPr0gramm.Response
{
    public class SyncResponse : Pr0grammResponse
    {
        public int InboxCount { get; private set; }
        public IReadOnlyList<object> Log { get; private set; } // TODO
        public int LogLength { get; private set; }
        public int Score { get; private set; }
    }
}
