using System.Linq;
using System.Net;

namespace AxUtils
{
    public static class NetworkUtils
    {
        public static bool IsLocalhost(string hostNameOrAddress)
        {
            if (string.IsNullOrEmpty(hostNameOrAddress))
            {
                return false;
            }

            try
            {
                IPAddress[] hostIPs = Dns.GetHostAddresses(hostNameOrAddress);
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                return hostIPs.Any(ipAddress => IPAddress.IsLoopback(ipAddress) || localIPs.Contains(ipAddress));
            }
            catch
            {
                return false;
            }
        }
    }
}
