using System;
using System.Net;

namespace aDevLib.Extensions
{
    public static class WebRequestExtensions
    {
        public static WebResponse GetResponseNoEx(this WebRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            try
            {
                return request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Response == null)
                    throw;
                return e.Response;
            }
        }
    }
}