using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;

namespace Techl.Diagnostics
{
    public static class PerformanceCounterHelper
    {
        public static float PrivateBytesInMB
        {
            get
            {
                return Process.GetCurrentProcess().PrivateMemorySize64 / 1024 / 1024;
            }
        }

        public static float AllHeapsBytesInMB
        {
            get
            {
                return AllHeapsBytesCounter.NextValue() / 1024 / 1024;
            }
        }

        public static int ThreadCount
        {
            get
            {
                return Process.GetCurrentProcess().Threads.Count;
            }
        }

        public static float CpuUsage
        {
            get
            {
                return CpuUsageCounter.NextValue();
            }
        }

        private static Timer LogTimer;
        private static DateTime LogStartTime;
        private static PerformanceCounter AllHeapsBytesCounter;
        private static PerformanceCounter CpuUsageCounter;

        public static void StartLog(int samplingIntervalSeconds = 60)
        {
            StopLog();

            if (!CreateCounter())
                return;

            CpuUsageCounter.NextValue();

            LogTimer = new Timer(samplingIntervalSeconds * 1000);
            LogTimer.Elapsed += LogTimer_Elapsed;
            LogTimer.Start();
            LogStartTime = DateTime.Now;
        }

        private static bool CreateCounter(bool isRetrying = false)
        {
            try
            {
                AllHeapsBytesCounter = new PerformanceCounter(".NET CLR Memory", "# bytes in all heaps", Process.GetCurrentProcess().ProcessName, true);
                CpuUsageCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);

                return true;
            }
            catch (InvalidOperationException ioe)
            {
                if (isRetrying)
                {
                    //https://stackoverflow.com/questions/17980178/cannot-load-counter-name-data-because-an-invalid-index-exception
                    Log.Write("PerformanceCounterHelper.Error", "the performance counter cache is corrupt. It requires to run 'lodctr /r' for rebuilding the cache. " + ioe.ToString());

                    return false;
                }
                else
                {
                    ProcessHelper.StartAndWaitForExit("lodctr", "/r");

                    return CreateCounter(true);
                }
            }
        }

        public static void StopLog()
        {
            if (AllHeapsBytesCounter != null)
            {
                AllHeapsBytesCounter.Dispose();
                AllHeapsBytesCounter = null;
            }

            if (CpuUsageCounter != null)
            {
                CpuUsageCounter.Dispose();
                CpuUsageCounter = null;
            }

            if (LogTimer != null)
            {
                LogTimer.Stop();
                LogTimer.Elapsed -= LogTimer_Elapsed;
                LogTimer = null;
            }
        }

        static void LogTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var fileName = Path.Combine(Log.BaseDirectory, "PerformanceCounter@" + LogStartTime.ToString("yyyyMMdd_HHmmss") + ".log");

            StreamWriter sw;
            if (File.Exists(fileName))
            {
                sw = File.AppendText(fileName);
            }
            else
            {
                sw = File.CreateText(fileName);
            }

            using (sw)
            {
                var content = CreateLogContent();
                Trace.WriteLine(content);
                sw.WriteLine(content);
            }
        }

        private static string CreateLogContent()
        {
            return String.Format("[{0}][{1}] PrivateBytes : {2:0.0}MB, AllHeapsBytes : {3:0.0}MB, Thread Count : {4}, CPU Usage : {5:0}%",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                DateTime.Now - LogStartTime,
                PrivateBytesInMB,
                AllHeapsBytesInMB,
                ThreadCount,
                CpuUsage
            );
        }
    }
}
