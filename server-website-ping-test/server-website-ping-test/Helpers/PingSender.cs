using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace server_website_ping_test.Helpers
{
    class PingSender : PingSenderFactory
    {
        public void SendPing(string address, string description, DateTime localDate, OutputObj output, WriterHelper writer, List<OutputObj> successList, List<OutputObj> failedList)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 5000;
            var reply = SendPingInternal(pingSender, timeout, buffer, options, address);

            if (reply == null)
            {
                var msg = @$"Time: {localDate.ToLongDateString()} - {localDate.ToLongTimeString()} {Environment.NewLine}Address: {address} {Environment.NewLine}Description: {description} {Environment.NewLine}Status: Sunucu Bulunamadı";
                var date = localDate.ToLongDateString() + " " + localDate.ToLongTimeString();
                Console.WriteLine(msg);
                output = new OutputObj
                {
                    Date = date,
                    Address = address,
                    Description = description,
                    Status = "Sunucu bulunamadı"
                };
                writer.WriteLog(output);
                failedList.Add(output);
            }
            else if (reply.Status == IPStatus.Success)
            {
                var msg = @$"Time: {localDate.ToLongDateString()} - {localDate.ToLongTimeString()} {Environment.NewLine}Address: {address} {Environment.NewLine}Description: {description} {Environment.NewLine}Status: {reply.Status}";
                var date = localDate.ToLongDateString() + " " + localDate.ToLongTimeString();
                Console.WriteLine(msg);
                output = new OutputObj
                {
                    Date = date,
                    Address = address,
                    Description = description,
                    Status = reply.Status.ToString()
                };
                writer.WriteLog(output);
                successList.Add(output);
            }
            else
            {
                var msg = @$"Time: {localDate.ToLongDateString()} - {localDate.ToLongTimeString()} {Environment.NewLine}Address: {address} {Environment.NewLine}Description: {description} {Environment.NewLine}Status: {reply.Status}";
                var date = localDate.ToLongDateString() + " " + localDate.ToLongTimeString();
                Console.WriteLine(msg);
                output = new OutputObj
                {
                    Date = date,
                    Address = address,
                    Description = description,
                    Status = reply.Status.ToString()
                };

                writer.WriteLog(output);
                failedList.Add(output);
            }
        }
        private PingReply SendPingInternal(Ping pingSender, int timeout, byte[] buffer, PingOptions options, string address)
        {
            try
            {

                return pingSender.Send(address, timeout, buffer, options);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
