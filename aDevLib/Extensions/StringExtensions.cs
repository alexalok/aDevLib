namespace aDevLib.Extensions
{
    public static class StringExtensions
    {
        public static string SmartSubstring(this string @string, int startIndex, int length)
        {
            return length >= 0 ?
                @string.Substring(startIndex, length) :
                @string.Substring(startIndex, @string.Length + length - startIndex);
        }
    }
}