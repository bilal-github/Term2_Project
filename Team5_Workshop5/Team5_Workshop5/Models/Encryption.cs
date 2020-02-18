/** Name: Bilal Ahmad
 * Date: Feb 13, 2020
 * Purpose: Encrypts passwords
 * Every user has a default credentials are UserID: [first name] and  password: 123123123
     */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team5_Workshop5.Models
{
    public static class Encryption
    {
        /// <summary>
        /// Encrypt password
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Encrypt(string plainText)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(plainText);
            return passwordHash;
        }
        /// <summary>
        /// Checks if the password matches the hashed password
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public static bool Verify(string plainText, string passwordHash)
        {
            bool Check = BCrypt.Net.BCrypt.Verify(plainText, passwordHash);
            return Check;
        }
    }
}