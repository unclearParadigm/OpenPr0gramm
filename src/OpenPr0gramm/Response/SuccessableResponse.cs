﻿namespace OpenPr0gramm.Response
{
#if FW
    [Serializable]
#endif
    public class SuccessableResponse : Pr0grammResponse
    {
        public bool Success { get; private set; }

        public SuccessableResponse()
        {
        }

        public SuccessableResponse(bool success)
        {
            Success = success;
        }
    }
}
