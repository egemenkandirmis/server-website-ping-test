using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_website_ping_test.Helpers
{
    public class WriterHelper
    {

        public void WriteLog(OutputObj output)
        {
            //File.AppendAllText("./output.txt", str + JsonConvert.SerializeObject(output));
            File.AppendAllLines("./output.txt", new[] { JsonConvert.SerializeObject(output) });


        }

        public static void DeleteExistingFile()
        {
            if (File.Exists("./output.txt"))
            {
                File.Delete("./output.txt");
            }
        }


    }
}

