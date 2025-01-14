﻿using System.Diagnostics;
using Refit;

namespace OpenPr0gramm.FormData
{
    public class AddTagsData : PostFormData
    {
        [AliasAs("itemId")] public int ItemId { get; }
        [AliasAs("submit")] public string Submit { get; }
        [AliasAs("tags")] public string Tags { get; set; }

        public AddTagsData(string nonce, int itemId, params string[] tags)
            : base(nonce)
        {
            Debug.Assert(tags != null);
            Tags = string.Join(",", tags);
            ItemId = itemId;
            Submit = "Tags speichern";
        }
    }
}
