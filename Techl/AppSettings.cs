// working
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techl
{
#if !DOTNET5_4
    public class AppSettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue">if the key does not exist, return defaultValue.</param>
        /// <returns></returns>
        public static T Get<T>(string key, T defaultValue)
        {
            var value = System.Configuration.ConfigurationManager.AppSettings.Get(key);
            if (value == null)
                return defaultValue;
            else
                return (T)Convert.ChangeType(value, typeof(T));
        }
    }
#endif
}
