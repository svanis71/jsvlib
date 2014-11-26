using System.Diagnostics;

namespace JSVLib.Extensions
{
    public static class StringExtensions
    {
        public static bool NullOrEmpty(this string s, bool trim = false)
        {
            return trim ? string.IsNullOrWhiteSpace(s) : string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// Moves the first n characters to the end.
        /// </summary>
        /// <param name="s">The string</param>
        /// <returns>A shifted string</returns>
        public static string LShift(this string s)
        {
            return s.LShift(1);
        }

        /// <summary>
        /// Moves the first n characters to the end.
        /// </summary>
        /// <param name="s">The string</param>
        /// <param name="n">Number of characters to move</param>
        /// <returns></returns>
        public static string LShift(this string s, int n)
        {
            if (s.NullOrEmpty() || s.Length <= n)
                return s;

            var s1 = s.Left(n);
            var s2 = s.Substring(n);
            return s2 + s1;
        }

        public static string Left(this string s, int n)
        {
            Debug.WriteLine(string.Format("Left({0}, {1})", s, n));
            if (s.NullOrEmpty())
                return s;
            if (n <= s.Length)
                return s.Substring(0, n);
            return s;
        }

        public static string Right(this string s, int n)
        {
            if (s.NullOrEmpty())
                return s;
            if (s.Length < n)
                return s.Substring(s.Length - n);
            return s;
        }
    }
}
