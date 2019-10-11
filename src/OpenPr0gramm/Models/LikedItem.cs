using Newtonsoft.Json;

namespace OpenPr0gramm.Models
{
    public class LikedItem : IPr0grammItem
    {
        public int Id { get; set; }

        /// <summary> Use the BaseAddress property of your HttpClient to prepend the protocol and host name. </summary>
        [JsonProperty(PropertyName = "thumb")]
        public string ThumbnailUrl { get; set; }

        public override string ToString() => $"{Id}, {ThumbnailUrl}";
    }
}
