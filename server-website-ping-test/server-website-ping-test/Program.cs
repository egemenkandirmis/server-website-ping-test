using server_website_ping_test.Helpers;
using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

namespace server_website_ping_test
{
    class Program
    {
        static bool exitSystem = false;

        #region Trap application termination
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

        private delegate bool EventHandler(CtrlType sig);
        static EventHandler _handler;

        enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        private static bool Handler(CtrlType sig)
        {
            Console.WriteLine("Exiting system due to external CTRL-C, or process kill, or shutdown");

            //do your cleanup here
            Thread.Sleep(3000); //simulate some cleanup delay


            Console.WriteLine("Cleanup complete");

            //allow main to run off
            exitSystem = true;

            //shutdown right away so there are no lingering threads
            Environment.Exit(-1);

            return true;
        }
        #endregion

        static void Main(string[] args)
        {
            //WriterHelper.DeleteExistingFile();
            ReaderHelper reader = new ReaderHelper();
            var list = reader.ReadJson2<WebsiteServer>(@"./jsonData.json");
            TimeHelper timeHelper = new TimeHelper();
            timeHelper.SetWebsiteServerList(list);
            timeHelper.SetTimerValues(60, 180);

            _handler += new EventHandler(Handler);
            SetConsoleCtrlHandler(_handler, true);

            //start your multi threaded program here
            Program p = new Program();

            //hold the console so it doesn’t run off the end
            while (!exitSystem)
            {
                Thread.Sleep(500);
            }

        }
        

    }
}
