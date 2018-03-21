// working
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Techl.Diagnostics
{
    public class Log
    {
        public static string BaseDirectory = Path.Combine(StorageHelper.LocalPath, "log");

        static Log()
        {
            if (!Directory.Exists(BaseDirectory))
                Directory.CreateDirectory(BaseDirectory);
        }

        private static string GetFileName(string category)
        {
            return Path.Combine(BaseDirectory, category + "@" + DateTime.Now.ToString("yyyyMMdd") + ".log");
        }

        public static void Write(string category, string message)
        {
            try
            {
                string filename = GetFileName(category);

                string content = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}][{category}] {message}";

                if (!File.Exists(filename))
                {
                    using (StreamWriter sw = File.CreateText(filename))
                    {
                        sw.WriteLine(content);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(filename))
                    {
                        sw.WriteLine(content);
                    }
                }

                Debug.WriteLine(content);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Log.Write Exception : {ex}");
            }
        }
    }
}
