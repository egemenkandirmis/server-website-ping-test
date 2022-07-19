using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_website_ping_test.Helpers
{
    public class ReaderHelper
    {
        public List<WebsiteServer> ReadJson()
        {
            string file = @"./jsonData.json";
            string fileText = File.ReadAllText(file);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WebsiteServer>>(fileText);
            return data;
        }


        public List<T> ReadJson2<T>(string path)
        {
            var str = File.ReadAllText(path);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(str);

            return data;
        }
    }
}
