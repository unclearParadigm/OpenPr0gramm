namespace OpenPr0gramm.Constants
{
    internal static class ClientConstants
    {
        internal const string OpenPr0grammVersion = "0.3.3"; // Also referenced in AssemblyInfo.cs

        internal const string ProtocolPrefix = "https://";

        internal const string HostName = "pr0gramm.com";

        internal const string BaseAddress = ProtocolPrefix + HostName;

        internal const string ApiBaseUrl = BaseAddress + "/api";

        // c# cannot evaluate functions at compile time (like C++ value templates), this is not cool. :(
        public static string GetUserAgent(string component) =>
            $"OpenPr0gramm/{OpenPr0grammVersion} ({component})";

        internal static string GetImageUrlPrefix =>
            ProtocolPrefix + "img." + HostName;
        internal static string GetThumbnailUrlPrefix =>
            ProtocolPrefix + "thumb." + HostName;
        internal static string GetFullSizeUrlPrefix =>
            ProtocolPrefix + "full." + HostName;

        internal const string BadgeUrlPrefix = ProtocolPrefix + HostName + "/media/badges";
        internal const string UserUrlPrefix = ProtocolPrefix + HostName + "/user";
    }
}
