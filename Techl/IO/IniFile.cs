// working
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Techl.Reflection;

namespace Techl.IO
{
    public class IniFile
    {
        public string Path { get; private set; }
        private int Capacity = 512;

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern long WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        public IniFile(string path = null)
        {
            Path = path ?? AssemblyHelper.GetEntryAssemblyFilePath() + ".ini";
        }

        public T Read<T>(string section, string key, T defaultValue)
        {
            var buffer = new StringBuilder(Capacity);
            GetPrivateProfileString(section, key, null, buffer, Capacity, Path);
            var valueString = buffer.ToString();
            if (valueString.IsNullOrEmpty())
                return defaultValue;
            else
                return ConvertHelper.Convert<T>(valueString, defaultValue);
        }

        public void Write<T>(string section, string key, T value)
        {
            WritePrivateProfileString(section, key, ConvertHelper.Convert<string>(value), Path);
        }

        public void DeleteKey(string section, string key)
        {
            WritePrivateProfileString(section, key, null, Path);
        }

        public void DeleteSection(string section)
        {
            WritePrivateProfileString(section, null, null, Path);
        }

        public string[] ReadSections()
        {
            while (true)
            {
                var buffer = new StringBuilder(Capacity);
                var size = GetPrivateProfileString(null, null, null, buffer, Capacity, Path);
                if (size == 0)
                    return null;

                if (size < buffer.Capacity - 2)
                    return buffer.ToString().Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);

                Capacity *= 2;
            }
        }

        public string[] ReadKeys(string section)
        {
            // first line will not recognize if ini file is saved in UTF-8 with BOM 
            while (true)
            {
                var buffer = new StringBuilder(Capacity);
                int size = GetPrivateProfileString(section, null, "", buffer, Capacity, Path);

                if (size == 0)
                    return null;

                if (size < Capacity - 2)
                {
                    string[] keys = buffer.ToString().Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
                    return keys;
                }

                Capacity *= 2;
            }
        }
    }
}
