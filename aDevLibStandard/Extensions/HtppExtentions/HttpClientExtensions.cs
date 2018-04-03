﻿using System.Net.Http;

namespace aDevLibStandard.Extensions.HtppExtentions
{
    public static class HttpClientExtensions
    {
        public static void SetUserAgent(this HttpClient httpClient, string userAgent)
        {
            httpClient.DefaultRequestHeaders.UserAgent.Clear();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
        }
    }
}