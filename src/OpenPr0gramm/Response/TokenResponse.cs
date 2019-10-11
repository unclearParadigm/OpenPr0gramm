namespace OpenPr0gramm.Response
{
#if FW
    [Serializable]
#endif
    public class TokenResponse : Pr0grammResponse
    {
        public string TokenError { get; private set; }
        public string Error { get; private set; }
    }
}
