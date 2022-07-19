using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_website_ping_test.Helpers
{
    public class HttpRequestHelper
    {
        public HttpRequestHelper(PingSenderFactory pingSenderFac, string address, string description, DateTime localDate, OutputObj output, WriterHelper writer, List<OutputObj> successList, List<OutputObj> failedList) => pingSenderFac.SendPing( address,description,  localDate,  output,  writer,  successList,  failedList);
    }
}