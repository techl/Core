// working
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Techl.Diagnostics;

namespace Techl
{
    public static class StringHelper
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return String.IsNullOrEmpty(value);
        }

        public static string[] SplitEx(this string str, string separator)
        {
            return str.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string StringJoin<T>(this IEnumerable<T> list, string separator)
        {
            return String.Join<T>(separator, list);
        }

        public static T Parse<T>(this string value)
        {
            if (typeof(T).GetTypeInfo().IsEnum)
            {
                return (T)Enum.Parse(typeof(T), value.ToString());
            }

            return (T)System.Convert.ChangeType(value, typeof(T));
        }

        [DebuggerNonUserCode]
        public static T Parse<T>(this string value, T defaultValue)
        {
            try
            {
                return Parse<T>(value);
            }
            catch (Exception ex)
            {
                Log.Write("StringHelper.Parse.Error", $"Original : {value}, Error : {ex}");
                return defaultValue;
            }
        }
    }
}
