using System;

namespace aDevLib.Extensions
{
    public static class UriExtensions
    {
        public static string ToRelative(this Uri uri)
        {
            // Null-check

            return uri.IsAbsoluteUri ? uri.PathAndQuery : uri.OriginalString;
        }

        public static string? ToAbsolute(this Uri uri, string baseUrl)
        {
            // Null-checks

            var baseUri = new Uri(baseUrl);

            return uri.ToAbsolute(baseUri);
        }

        public static string? ToAbsolute(this Uri uri, Uri baseUri)
        {
            // Null-checks

            var relative = uri.ToRelative();

            if (Uri.TryCreate(baseUri, relative, out var absolute))
            {
                return absolute.ToString();
            }

            return uri.IsAbsoluteUri ? uri.ToString() : null;
        }
    }
}