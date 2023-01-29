
using System;
using System.Net.NetworkInformation;
using Xunit;

namespace srvlocal_gui
{

    public class NetworkTests
    {
        [Fact]
        public void TestLocalhostReachability()
        {
            bool reachable = false;
            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send("localhost", 8080);
                reachable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
            }
            Assert.True(reachable);
        }
    }
}
