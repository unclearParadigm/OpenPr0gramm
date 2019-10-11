using OpenPr0gramm.Models;

namespace OpenPr0gramm.Response
{
#if FW
    [Serializable]
#endif
    public class LogInResponse : SuccessableResponse
    {
        public BanInfo Ban { get; private set; }
    }
}
