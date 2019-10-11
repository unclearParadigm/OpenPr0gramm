using System;

namespace OpenPr0gramm
{
    /// <summary>Some utility extensions on <typeparam name="DateTime"/>.</summary>
    internal static class DateTimeExtensions
    {
        public static long ToUnixTime(this DateTime value)
        {
            var dtOffset = new DateTimeOffset(value);
            return dtOffset.ToUnixTimeSeconds();
        }
    }
}
