using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team5_Workshop5.Models
{
    public static class Encryption
    {
        public static string Encrypt(string plainText)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(plainText);
            return passwordHash;
        }

        public static bool Verify(string plainText, string passwordHash)
        {
            bool Check = BCrypt.Net.BCrypt.Verify(plainText, passwordHash);
            return Check;
        }
    }
}