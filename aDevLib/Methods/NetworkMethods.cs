using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace aDevLib.Methods
{
    public class NetworkMethods
    {
        public static async Task<int> GetAveragePing(string hostnameOrIp, int pingAmount)
        {
            if (!IPAddress.TryParse(hostnameOrIp, out var ip))
            {
                var addresses = await Dns.GetHostAddressesAsync(hostnameOrIp);
                if (addresses.Length > 0)
                    ip = addresses[0];
                else
                    throw new ArgumentException("Passed address is neither IP nor DNS name");
            }
            var totalPing = 0L;
            var pinger = new Ping();
            for (var i = 0; i < pingAmount; i++)
            {
                var pingReply = await pinger.SendPingAsync(ip);
                if (pingReply.Status != IPStatus.Success)
                    throw new Exception("Ping wasn't successful");
                totalPing += pingReply.RoundtripTime;
            }
            return Convert.ToInt32(totalPing / pingAmount);
        }
    }
}