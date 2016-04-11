using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using System.Threading;

namespace UIBackup
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var todaysDate = System.DateTime.Now.Date.Day;
                if (Convert.ToInt16(todaysDate) % 2 == 0)
                {
                    var zip = new ZipFile(@"D:\WOWUIBACKUPS\UIBackup" + System.DateTime.Today.Month.ToString() + System.DateTime.Today.Day.ToString() + System.DateTime.Today.Year.ToString() + ".zip");
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                    zip.CompressionMethod = CompressionMethod.BZip2;
                    string strAddons = @"C:\Program Files (x86)\World of Warcraft\Interface";
                    string strWTF = @"C:\Program Files (x86)\World of Warcraft\WTF";
                    zip.AddDirectory(strAddons);
                    zip.AddDirectory(strWTF);
                    zip.SaveProgress += (sender, e) => {
                        if (e.EventType == ZipProgressEventType.Saving_BeforeWriteEntry)
                        {
                            Console.WriteLine("  Writing: ({0}/{1})", e.EntriesSaved, e.EntriesTotal);
                        }
                    };
                    zip.Save(@"D:\WOWUIBACKUPS\UIBackup" + System.DateTime.Today.Month.ToString() + System.DateTime.Today.Day.ToString() + System.DateTime.Today.Year.ToString() + ".zip");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message.ToString());
                Console.WriteLine("Press any key to close");
                Console.ReadKey();
            }
            
        }
    }
}
