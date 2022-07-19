using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_website_ping_test.Helpers
{
    public interface PingSenderFactory
    {
        public void SendPing(string address, string description, DateTime localDate, OutputObj output, WriterHelper writer, List<OutputObj> successList, List<OutputObj> failedList);
    }
}
