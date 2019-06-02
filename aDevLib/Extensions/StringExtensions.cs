﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Media;

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

        public static bool IsInt(this string input) => int.TryParse(input, out int _);

        public static bool ToBool(this string input)
        {
            if (!TryToBool(input, out bool result))
                throw new FormatException();

            return result;
        }

        public static bool TryToBool(this string input, out bool result)
        {
            if (bool.TryParse(input, out result))
                return true;

            if (input.All(char.IsDigit))
            {
                result = input != "0";
                return true;
            }

            return false;
        }

        public static bool? TryToBool(this string input)
        {
            if (!TryToBool(input, out bool result))
                return null;
            return result;
        }

        public static string EscapeXML(this string input)
        {
            return input.
                Replace("&",  "&amp;").
                Replace("<",  "&lt;").
                Replace(">",  "&gt;").
                Replace("\"", "&quot;").
                Replace("'",  "&apos;");
        }

        public static string NewLineConcatenated(this IEnumerable<string> multiLineString) =>
            string.Join(Environment.NewLine, multiLineString);

        public static string GetMd5(this string input, bool upperCase = true)
        {
            var    md5        = MD5.Create();
            var    inputBytes = Encoding.ASCII.GetBytes(input);
            var    hash       = md5.ComputeHash(inputBytes);
            string format     = upperCase ? "X2" : "x2";
            string res        = string.Join(string.Empty, hash.Select(h => h.ToString(format)));
            return res;
        }

        public static bool IsValidEmail(this string obj) =>
            Regex.IsMatch(obj, "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z0-9]{1,30})(\\]?)$");

        public static string[] ToStringsArray(this string str)
        {
            return new[] {str};
        }
    }
}