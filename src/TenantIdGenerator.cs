using System;
using System.Security.Cryptography;
using System.Text;

namespace YA.Common
{
    public static class TenantIdGenerator
    {
        public static Guid Create(string userId)
        {
            Guid result;

            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(userId));
                result = new Guid(hash);
            }

            return result;
        }
    }
}
