using Newtonsoft.Json;

namespace OpenPr0gramm.Models
{
#if FW
    [Serializable]
#endif
    public class ProfileUpload : IPr0grammItem
    {
        public int Id { get; set; }

        /// <summary> Use the BaseAddress property of your HttpClient to prepend the protocol and host name. </summary>
        [JsonProperty(PropertyName = "thumb")]
        public string ThumbnailUrl { get; set; }

        public override string ToString() => $"{Id}, {ThumbnailUrl}";
    }
}
