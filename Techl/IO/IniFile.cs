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
    /// <summary>
    /// Handle initialization file(*.ini)
    /// </summary>
    public class IniFile
    {
        public string Path { get; private set; }
        private int Capacity = 512;

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, char[] lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern long WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileSection(string section, char[] keyValue, int size, string filePath);

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
                var buffer = new char[Capacity];
                var size = GetPrivateProfileString(null, null, null, buffer, Capacity, Path);
                if (size == 0)
                    return null;

                if (size < buffer.Length - 2)
                    return new string(buffer, 0, size).Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);

                Capacity *= 2;
            }
        }

        public string[] ReadKeys(string section)
        {
            // first line will not recognize if ini file is saved in UTF-8 with BOM 
            while (true)
            {
                var buffer = new char[Capacity];
                int size = GetPrivateProfileString(section, null, "", buffer, Capacity, Path);

                if (size == 0)
                    return null;

                if (size < Capacity - 2)
                {
                    string[] keys = new string(buffer, 0, size).Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
                    return keys;
                }

                Capacity *= 2;
            }
        }

        public Dictionary<string, string> ReadSection(string section)
        {
            while (true)
            {
                var buffer = new char[Capacity];
                int size = GetPrivateProfileSection(section, buffer, Capacity, Path);

                if (size == 0)
                {
                    return null;
                }

                if (size < Capacity - 2)
                {
                    var keyValues = new string(buffer, 0, size).Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Split('='));
                    return keyValues.ToDictionary(s => s[0], s => s[1]);
                }

                Capacity = Capacity * 2;
            }
        }
    }
}
