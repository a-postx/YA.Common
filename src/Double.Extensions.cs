using System;

namespace YA.Common
{
    public static class DoubleExtensions
    {
        ///<summary>Returns DateTime converted from Unix time stamp format.</summary>
        ///<param name="unixTimeStamp">The number to convert the date from.</param>
        public static DateTime UnixTimeStampToDateTime(this double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
