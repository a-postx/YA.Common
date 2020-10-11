using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace YA.Common
{
    public static class NetTools
    {
        public static async Task<bool> CheckPingAsync(this IPAddress ip, int timeoutMs = 2000)
        {
            bool result = false;

            try
            {
                PingReply reply;

                using (Ping ping = new Ping())
                {
                    reply = await ping.SendPingAsync(ip, timeoutMs).ConfigureAwait(false);
                }

                if (reply.Status == IPStatus.Success)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error checking ping to " + ip + ".", e);
            }

            return result;
        }

        public static async Task<bool> CheckTcpConnectionAsync(string host, int port, int sendTimeout = 0, int receiveTimeout = 0)
        {
            bool result = false;

            using (TcpClient tcpClient = new TcpClient { ReceiveTimeout = receiveTimeout, SendTimeout = sendTimeout })
            {
                try
                {
                    await tcpClient.ConnectAsync(host, port).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new Exception("Error checking TCP connection to " + host + ":" + port + ".", e);
                }
                finally
                {
                    if (tcpClient.Connected)
                    {
                        tcpClient.Close();
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}
