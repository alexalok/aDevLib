using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace aDevLib
{
    public class aPing
    {
        public async int GetAveragePing(string hostnameOrIp, int pingAmount)
        {
            IPAddress ip;
            if (!IPAddress.TryParse(hostnameOrIp, out ip))
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
                    throw PingException
                totalPing += ().RoundtripTime;
            }
            return Convert.ToInt32(totalPing);
        }
    }
}