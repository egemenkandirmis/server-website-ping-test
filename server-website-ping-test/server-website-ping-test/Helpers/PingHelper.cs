using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace server_website_ping_test.Helpers
{
    public class PingHelper
    {
        WriterHelper writer = new WriterHelper();
        OutputObj output;
        List<OutputObj> successList = new List<OutputObj>();
        List<OutputObj> failedList = new List<OutputObj>();
        DateTime localDate;

        MailHelper mailHelper = new MailHelper();

        public void SendPingToAll(List<WebsiteServer> list)
        {
            successList.Clear();
            failedList.Clear();
            foreach (var item in list)
            {
                try
                {
                    localDate = DateTime.Now;
                    SendPing(item.IpAddress, item.Description);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    output = new OutputObj
                    {
                        Date = localDate.ToString(),
                        Address = item.IpAddress,
                        Description = item.Description,
                        Status = e.Message
                    };
                    failedList.Add(output);
                }
            }
            Console.WriteLine("Circle Completed !!!!");
            Console.WriteLine("**********************");
            string textBody = "" +
                "<table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 800 + ">" +
                "<tr bgcolor='#4da6ff'>" +
                "<td> <b> Date</b></td>" +
                "<td> <b> Ip Address</b> </td>" +
                "<td> <b> Description</b> </td>" +
                "<td> <b> Status</b> </td>" +
                "</tr>";
            foreach (var item in failedList)
            {
                textBody += "<tr bgcolor='#f96363'><td>" + item.Date + "</td><td> " + item.Address + "</td>" + "<td>" + item.Description + "</td><td> " + item.Status + "</td> </tr>";
            }
            foreach (var item in successList)
            {
                textBody += "<tr><td>" + item.Date + "</td><td> " + item.Address + "</td>" + "<td>" + item.Description + "</td><td> " + item.Status + "</td> </tr>";
            }
            textBody += "</table>";

            Console.WriteLine(failedList.Count);
            if(failedList.Count > 0)
            {
                mailHelper.SendFullReportMail(ConstantStrings.FROM_MAIL_ADDRESS, "kandirmis@gmail.com", "Sunucu Website Kontrol Raporu", textBody);
            }
            else
            {
                mailHelper.SendMail(ConstantStrings.FROM_MAIL_ADDRESS, "kandirmis@gmail.com", "Sunucu Website Kontrol Raporu", textBody);
            }

            //Console.WriteLine(textBody);
        }

        public void SendPing(string address, string description)
        {
            
            if (address.Contains("http"))
            {
                new HttpRequestHelper(new HttpReq(),address,description,localDate,output,writer,successList,failedList);
            }
            else
            {
                new PingSenderHelper(new PingSender(), address, description, localDate, output, writer, successList, failedList);
            }
        }

       
    }
}
