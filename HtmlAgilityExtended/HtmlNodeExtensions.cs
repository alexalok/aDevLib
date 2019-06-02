using System.Linq;
using HtmlAgilityPack;
using JetBrains.Annotations;

namespace HtmlAgilityExtended
{
    public static class HtmlNodeExtensions
    {
        [CanBeNull]
        public static HtmlNode GetFirstNonTextChildNode(this HtmlNode node) => node.ChildNodes.FirstOrDefault(n => !n.Name.StartsWith("#"));
    }
}