using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JSVLib.Extensions
{
    public static class GuidExtensions
    {
        public static Guid ToGuid(this string s)
        {
            var str = new StringBuilder(s);
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(str.ToString()));
            return new Guid(data);
        }

        public static int ToInt(this Guid guid)
        {
            /// http://forums.asp.net/t/1266765.aspx
            //extract an integer from the beginning of the Guid
            byte[] _bytes = guid.ToByteArray();
            return ((int)_bytes[0]) | ((int)_bytes[1] << 8) | ((int)_bytes[2] << 16) | ((int)_bytes[3] << 24);

        }

    }
}
