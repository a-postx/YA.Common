using System;
using System.Text;

namespace YA.Common.Extensions
{
    public static class StringExtensions
    {
        ///<summary>Возвращает текст, закодированный в Base64.</summary>
        public static string Base64Encode(this string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                throw new Exception("Невозможно закодировать пустую строку.");
            }

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        ///<summary>Возвращает текст, раскодированный из Base64.</summary>
        public static string Base64Decode(this string base64EncodedData)
        {
            if (string.IsNullOrEmpty(base64EncodedData))
            {
                throw new Exception("Невозможно раскодировать пустую строку.");
            }

            byte[] base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
