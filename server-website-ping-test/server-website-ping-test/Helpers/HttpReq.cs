using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace server_website_ping_test.Helpers
{
    public class HttpReq : PingSenderFactory
    {
        public void SendPing(string address, string description, DateTime localDate, OutputObj output, WriterHelper writer, List<OutputObj> successList, List<OutputObj> failedList)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            HttpStatusCode status = response.StatusCode;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
            Console.WriteLine(status);
            if (response == null)
            {
                var msg = @$"Time: {localDate.ToLongDateString()} - {localDate.ToLongTimeString()} {Environment.NewLine}Address: {address} {Environment.NewLine}Description: {description} {Environment.NewLine}Status: Websitesi Bulunamadı";
                var date = localDate.ToLongDateString() + " " + localDate.ToLongTimeString();
                Console.WriteLine(msg);
                output = new OutputObj
                {
                    Date = date,
                    Address = address,
                    Description = description,
                    Status = "Websitesi Bulunamadı"
                };
                writer.WriteLog(output);
                failedList.Add(output);
            }
            else if (response.StatusCode == HttpStatusCode.OK)
            {
                var msg = @$"Time: {localDate.ToLongDateString()} - {localDate.ToLongTimeString()} {Environment.NewLine}Address: {address} {Environment.NewLine}Description: {description} {Environment.NewLine}Status: {status}";
                var date = localDate.ToLongDateString() + " " + localDate.ToLongTimeString();
                Console.WriteLine(msg);
                output = new OutputObj
                {
                    Date = date,
                    Address = address,
                    Description = description,
                    Status = status.ToString()
                };
                writer.WriteLog(output);
                successList.Add(output);
            }
            else
            {
                var msg = @$"Time: {localDate.ToLongDateString()} - {localDate.ToLongTimeString()} {Environment.NewLine}Address: {address} {Environment.NewLine}Description: {description} {Environment.NewLine}Status: {status}";
                var date = localDate.ToLongDateString() + " " + localDate.ToLongTimeString();
                Console.WriteLine(msg);
                output = new OutputObj
                {
                    Date = date,
                    Address = address,
                    Description = description,
                    Status = "Websitesi Bulunamadı"
                };
                writer.WriteLog(output);
                failedList.Add(output);
            }
        }
    }
}
