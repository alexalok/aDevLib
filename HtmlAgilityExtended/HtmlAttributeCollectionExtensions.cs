using HtmlAgilityPack;

namespace HtmlAgilityExtended
{
    public static class HtmlAttributeCollectionExtensions
    {
        public static void Add(this HtmlAttributeCollection collection, string name, object value)
        {
            collection.Add(name, value.ToString());
        }
    }
}