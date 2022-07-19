using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace server_website_ping_test.Helpers
{
    public class TimeHelper
    {
        static int _seconds, _multiplier;
        static PingHelper pingHelper = new PingHelper();
        static List<WebsiteServer> _list = new List<WebsiteServer>();

        Thread timer = new Thread(new ThreadStart(InvokeMethod));
        public static void InvokeMethod()
        {
            while (true)
            {
                try
                {
                    SendPingReq();
                    Console.WriteLine("Circle Completed!!!");
                    Console.WriteLine("********************");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Before Sleep");
                Thread.Sleep(1000 * _seconds * _multiplier);

            }
        }
        public void SetWebsiteServerList(List<WebsiteServer> list)
        {
            _list = list;
        }
        public void SetTimerValues(int seconds, int multiplier)
        {
            _seconds = seconds;
            _multiplier = multiplier;
            timer.Start();
        }
        public static List<WebsiteServer> GetWebsiteServerList()
        {
            return _list;
        }

        static void SendPingReq()
        {
            pingHelper.SendPingToAll(GetWebsiteServerList());
        }
    }
}
