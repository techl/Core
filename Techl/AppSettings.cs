using Microsoft.Extensions.Configuration;
using System;

namespace Techl
{
    public class AppSettings
    {
        private static IConfiguration Configuration;

        public static void Initialize(IConfiguration configuration = null)
        {
            if (configuration == null)
            {
                configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true).Build();
            }

            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue">if the key does not exist, return defaultValue.</param>
        /// <returns></returns>
        public static T Get<T>(string key, T defaultValue)
        {
            if (Configuration == null)
                return defaultValue;
            else
            {
                try
                {
                    return (T)Convert.ChangeType(Configuration[key], typeof(T));
                }
                catch
                {
                    return defaultValue;
                }
            }
        }
    }
}