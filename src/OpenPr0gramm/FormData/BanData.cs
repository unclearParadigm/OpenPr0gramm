﻿using System.Diagnostics;
using Refit;

namespace OpenPr0gramm.FormData
{
    public class BanData : PostFormData
    {
        [AliasAs("user")] public string User { get; set; }
        [AliasAs("reason")] public string Reason { get; set; }
        [AliasAs("days")] public int Days { get; set; }

        public BanData(string nonce, string user, string reason, int days)
            : base(nonce)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(user));
            User = user;
            Reason = reason;
            Days = days;
        }
    }
}
