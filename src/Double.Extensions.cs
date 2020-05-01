using System;

namespace YA.Common
{
    public static class DoubleExtensions
    {
        ///<summary>Возвращает ДатаВремя, конвертированное из формата Юникс.</summary>
        public static DateTime UnixTimeStampToDateTime(this double unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
