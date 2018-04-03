using System;
using System.Globalization;
using HtmlAgilityPack;

namespace HtmlAgilityExtended
{
    public static class HtmlAttributeExtensions
    {
        public static bool BoolValue(this HtmlAttribute attribute)
        {
            return Convert.ToInt32(attribute.Value) == 1;
        }

        public static int IntValue(this HtmlAttribute attribute)
        {
            return Convert.ToInt32(attribute.Value);
        }

        public static bool TryIntValue(this HtmlAttribute attribute, out int value)
        {
            return int.TryParse(attribute.Value, out value);
        }

        public static long LongValue(this HtmlAttribute attribute)
        {
            return Convert.ToInt64(attribute.Value);
        }

        public static bool TryLongValue(this HtmlAttribute attribute, out long value)
        {
            return long.TryParse(attribute.Value, out value);
        }

        public static float FloatValue(this HtmlAttribute attribute)
        {
            return Convert.ToSingle(attribute.Value, CultureInfo.InvariantCulture);
        }
    }
}