using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techl.Diagnostics
{
    public class ProcessHelper
    {
        public static void StartAndWaitForExit(string fileName, string arguments, bool runAsAdministrator = false)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                UseShellExecute = true,
                FileName = fileName,
                Arguments = arguments
            };
            if (runAsAdministrator)
                processStartInfo.Verb = "runas";

            Process process = Process.Start(processStartInfo);
            process.WaitForExit();
        }
    }
}
