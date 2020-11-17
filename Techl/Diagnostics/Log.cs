// working
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using Techl.Reflection;

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
            string fileName = GetFileName(category);
            string content = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}][{category}] {message}";

            WriteInternal(fileName, content);
        }

        public static void WriteInfo(string message)
        {
            var fileName = Path.GetFileNameWithoutExtension(AssemblyHelper.GetEntryAssemblyFilePath()) + ".log";
            string content = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}] {message}";

            WriteInternal(fileName, content);
        }

        private static void WriteInternal(string fileName, string content)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        sw.WriteLine(content);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        sw.WriteLine(content);
                    }
                }

                Debug.WriteLine(content);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Log.Write Exception : {ex}");

                var exContent = ex.ToString() + $"\nContent={content}";
                var errorFileName = GetFileName("Log.Write.Error");
                
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        if (!File.Exists(errorFileName))
                        {
                            using (StreamWriter sw = File.CreateText(errorFileName))
                            {
                                sw.WriteLine(exContent);
                            }
                        }
                        else
                        {
                            using (StreamWriter sw = File.AppendText(errorFileName))
                            {
                                sw.WriteLine(exContent);
                            }
                        }

                        return;
                    }
                    catch
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
        }
    }
}
