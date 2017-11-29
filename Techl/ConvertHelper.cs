// working
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techl.Diagnostics;

namespace Techl
{
    public static class ConvertHelper
    {
        public static T Convert<T>(object value)
        {
            if (typeof(T).IsEnum)
            {
                if (value is string)
                {
                    return (T)Enum.Parse(typeof(T), value.ToString());
                }
            }

            return (T)System.Convert.ChangeType(value, typeof(T));
        }

        [DebuggerNonUserCode]
        public static T Convert<T>(object value, T defaultValue)
        {
            try
            {
                T convertedValue = Convert<T>(value);
                return convertedValue;
            }
            catch (Exception ex)
            {
                Log.Write("ConvertHelper.Error", $"Original : {value}, Error : {ex.ToString()}");
                return defaultValue;
            }
        }

        public static T Convert<T>(this string valueString, T defaultValue)
        {
            return Convert<T>((object)valueString, defaultValue);
        }

        [DebuggerNonUserCode]
        public static bool TryConvert<T>(object value, out T convertedValue)
        {
            try
            {
                convertedValue = Convert<T>(value);
                return true;
            }
            catch
            {
                convertedValue = default(T);
                return false;
            }
        }
    }
}
