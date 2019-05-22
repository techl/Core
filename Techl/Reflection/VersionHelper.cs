using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Techl.Reflection
{
    public static class VersionHelper
    {
        public static string ToString(this Version version, int fieldCount)
        {
            switch (fieldCount)
            {
                case 1:
                    return version.Build.ToString();
                case 2:
                    return String.Format("{0}.{1}", version.Major, version.Minor);
                case 3:
                    return String.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build);
                case 4:
                    return version.ToString();
                default:
                    return "";
            }
        }

        public static string GetVersion(int fieldCount = 3)
        {
            return Assembly.GetEntryAssembly()?.GetName().Version.ToString(fieldCount);
        }
    }
}
