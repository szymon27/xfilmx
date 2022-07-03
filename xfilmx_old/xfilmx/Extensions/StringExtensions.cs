using System.Security.Cryptography;
using System.Text;

namespace xfilmx.Extensions
{
    public static class StringExtensions
    {
        public static string ToPassword(this string str)
        {
            return Encoding.UTF8.GetString(SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(str)));
        }
    }
}
