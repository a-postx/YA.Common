using System;

namespace YA.Common
{
    public static class DateTimeExtensions
    {
        ///<summary>Converts a datetime into unix time format.</summary>
        public static double ToUnixTimestamp(this DateTime dateTime)
        {
            return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
                    new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
    }
}
