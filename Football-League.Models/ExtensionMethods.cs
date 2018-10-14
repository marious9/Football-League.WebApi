using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Football_League.Models
{
    public static class ExtensionMethods
    {
        public static string ToHash(this string text)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
