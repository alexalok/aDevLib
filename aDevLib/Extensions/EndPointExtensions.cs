using System.Net;

namespace aDevLib.Extensions
{
    public static class EndPointExtensions
    {
        public static IPEndPoint GetIPEndPoint(this EndPoint endPoint)
        {
            return endPoint as IPEndPoint;
        }
    }
}