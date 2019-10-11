namespace OpenPr0gramm.Response
{
#if FW
    [Serializable]
#endif
    public class ChangeUserDataResponse : Pr0grammResponse
    {
        public string Account { get; private set; }
        public string Error { get; private set; }
    }
}
