using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace fortnite
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringSeparators = new string[] { "\r\n" };
            string filePath = @"C:\Users\nalac\Desktop\Fortnite.json";
            using (var wb = new WebClient())
            {
                wb.Headers.Set("TRN-Api-Key","4a27df76-0804-4e62-872c-f878112d1db2");
                string path = "https://api.fortnitetracker.com/v1/profile/pc/NalaCat";
                string html = wb.DownloadString(path);
                string replaced = html.Replace("\r\n", string.Empty);
                string[] lines = JsonConvert.SerializeObject(path, Formatting.Indented).Split(stringSeparators, StringSplitOptions.None);
                //File.WriteAllText(@"C:\Users\nalac\Desktop\Movies.json",JsonConvert.SerializeObject(html,Formatting.Indented));

                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
