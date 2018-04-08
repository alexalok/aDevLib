using System.Linq;

namespace aDevLibStandard.Methods
{
    public class RandomMethods
    {
        public static string GetRandomString(int length, bool onlyDigits = false)
        {
            var chars = "0123456789";
            if (!onlyDigits)
                chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length).
                Select(s => s[SRandom.Next(s.Length)]).ToArray());
        }
    }
}