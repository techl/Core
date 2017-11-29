// working
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Techl.Reflection
{
    public static class AssemblyHelper
    {
        public static string GetEntryAssemblyFilePath()
        {
            //Console.WriteLine(Assembly.GetEntryAssembly().Location);
            //Console.WriteLine(Process.GetCurrentProcess().MainModule.FileName);
            //Console.WriteLine(Application.ExecutablePath);
            //Console.WriteLine(new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath);
            //Console.ReadKey();

            /*
            On Windows
            Assembly.GetEntryAssembly().Location : OK
            Process.GetCurrentProcess().MainModule.FileName : OK
            Application.ExecutablePath : OK
            new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath : OK

            On Windows with Host
            Assembly.GetEntryAssembly().Location : Shadow Copied Path
            Process.GetCurrentProcess().MainModule.FileName : Host File
            Application.ExecutablePath : OK
            new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath : OK

            On Linux Mono v5.2.0.215
            Assembly.GetEntryAssembly().Location : OK
            Process.GetCurrentProcess().MainModule.FileName : /usr/bin/mono-sgen
            Application.ExecutablePath : OK
            new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath : OK

            On Linux Mono v5.2.0.215 with Host
            Assembly.GetEntryAssembly().Location : OK
            Process.GetCurrentProcess().MainModule.FileName : /usr/bin/mono-sgen
            Application.ExecutablePath : Host File
            new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath : OK
            */

            return new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath;
        }
    }
}
