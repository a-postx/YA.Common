using System;

namespace YA.Common
{
    public static class DateTimeExtensions
    {
        ///<summary>Возвращает дату конвертированную в Юникс-формат.</summary>
        public static double ToUnixTimestamp(this DateTime dateTime)
        {
            return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
                    new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
    }
}
