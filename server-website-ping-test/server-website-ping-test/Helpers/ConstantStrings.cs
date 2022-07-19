using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_website_ping_test.Helpers
{
    public static class ConstantStrings
    {
        public static string PASSWORD = "978-605-66225";
        public static string FROM_MAIL_ADDRESS = @"info@zafer.org.tr";
        public static string FROM_MAIL_DISPLAY_NAME = @"Server Website Kontrol";
        public static string CC_MAIL_ADDRESS = @"denemeCC@gmail.com";

        public static List<string> MAIL_ADDRESS_LIST = new List<string>()
        {
            "bt2@zafer.gov.tr"
        };
        public static List<string> TO_COMPLETE_REPORT_MAIL_ADDRESS_LIST = new List<string>()
        {
            @"bt@zafer.gov.tr"
        };
    }
}
