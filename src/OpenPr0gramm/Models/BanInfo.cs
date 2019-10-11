﻿using System;
using Newtonsoft.Json;
using OpenPr0gramm.Json;

namespace OpenPr0gramm.Models
{
#if FW
    [Serializable]
#endif
    public class BanInfo
    {
        [JsonProperty(PropertyName = "banned")]
        public bool IsBanned { get; set; }

        [JsonProperty(PropertyName = "till")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Until { get; set; }

        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }
    }
}
