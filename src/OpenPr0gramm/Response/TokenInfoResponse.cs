using OpenPr0gramm.Models;

namespace OpenPr0gramm.Response
{
#if FW
    [Serializable]
#endif
    public class TokenInfoResponse : Pr0grammResponse
    {
        public Token Token { get; private set; }
    }
}
