using System;
using Newtonsoft.Json;
using OpenPr0gramm.Constants;
using OpenPr0gramm.Json;
using OpenPr0gramm.Structures;

namespace OpenPr0gramm.Models
{
#if FW
    [Serializable]
#endif
    public class Item : IPr0grammItem
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "promoted")]
        public int PromotedId { get; set; }

        [JsonProperty(PropertyName = "up")] public int Upvotes { get; set; }
        [JsonProperty(PropertyName = "down")] public int Downvotes { get; set; }

        [JsonProperty(PropertyName = "created")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary> Use the BaseAddress property of your HttpClient to prepend the protocol and host name. </summary>
        [JsonProperty(PropertyName = "image")]
        public string ImageUrl { get; set; }

        /// <summary> Use the BaseAddress property of your HttpClient to prepend the protocol and host name. </summary>
        [JsonProperty(PropertyName = "thumb")]
        public string ThumbnailUrl { get; set; }

        /// <summary> Use the BaseAddress property of your HttpClient to prepend the protocol and host name. </summary>
        [JsonProperty(PropertyName = "fullsize")]
        public string FullSizeUrl { get; set; }

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "flags")]
        public ItemFlags Flags { get; set; }

        [JsonProperty(PropertyName = "user")]
        public string User { get; set; }

        [JsonProperty(PropertyName = "mark")]
        public UserMark Mark { get; set; }

        public ItemType GetItemType()
        {
            var url = ImageUrl;
            if (string.IsNullOrWhiteSpace(url))
                return ItemType.Unknown;
            return url.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase) ? ItemType.Video : ItemType.Image;
        }

        public string GetAbsoluteThumbnailUrl =>
            ClientConstants.GetThumbnailUrlPrefix + "/" + ThumbnailUrl;

        public string GetAbsoluteFullSizeUrl => FullSizeUrl == null
            ? GetAbsoluteImageUrl
            : ClientConstants.GetFullSizeUrlPrefix + "/" + FullSizeUrl;

        public string GetAbsoluteImageUrl =>
            ClientConstants.GetImageUrlPrefix + "/" + ImageUrl;
    }

    public enum ItemType
    {
        Unknown, // TODO consider
        Image,
        Video
    }

    public interface IPr0grammItem
    {
        int Id { get; }
    }
}
