// working
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Techl
{
    public static class EnumHelper
    {
        public static string GetDisplayName(this Enum value)
        {
            FieldInfo info = value.GetType().GetField(value.ToString());
            DisplayAttribute attribute = info.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() as DisplayAttribute;

            return attribute != null ? attribute.Name : value.ToString();
        }

        public static string GetDescription(this Enum value)
        {
            FieldInfo info = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = info.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault() as DescriptionAttribute;

            return attribute != null ? attribute.Description : value.ToString();
        }


        public static string GetCategory(this Enum value)
        {
            FieldInfo info = value.GetType().GetField(value.ToString());
            CategoryAttribute attribute = info.GetCustomAttributes(typeof(CategoryAttribute), true).FirstOrDefault() as CategoryAttribute;

            return attribute != null ? attribute.Category : value.ToString();
        }

        public static TEnum Parse<TEnum>(string value) where TEnum : struct, IConvertible
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value, false);
        }

        public static TEnum Parse<TEnum>(string value, TEnum defaultValue) where TEnum : struct, IConvertible
        {
            TEnum result;
            if (Enum.TryParse<TEnum>(value, out result))
                return result;
            else
                return defaultValue;
        }

        public static object ParseDisplayName(Type type, string displayName)
        {
            AssertEnum(type);

            foreach (var item in Enum.GetValues(type))
            {
                if (GetDisplayName((Enum)item).Equals(displayName))
                {
                    return item;
                }
            }

            throw new ArgumentException("The string is not a description or name of the specified enum.");
        }

        public static TEnum ParseDisplayName<TEnum>(string displayName) where TEnum : struct, IConvertible
        {
            return (TEnum)ParseDisplayName(typeof(TEnum), displayName);
        }

        public static object ParseDescription(Type type, string description)
        {
            AssertEnum(type);

            foreach (var item in Enum.GetValues(type))
            {
                if (GetDescription((Enum)item).Equals(description))
                {
                    return item;
                }
            }

            throw new ArgumentException("The string is not a description or name of the specified enum.");
        }

        public static TEnum ParseDescription<TEnum>(string description) where TEnum : struct, IConvertible
        {
            return (TEnum)ParseDescription(typeof(TEnum), description);
        }

        public static bool TryParseDescription<T>(string description, out T parseResult) where T : struct, IConvertible
        {
            try
            {
                parseResult = ParseDescription<T>(description);
                return true;
            }
            catch (ArgumentException)
            {
                parseResult = default(T);
                return false;
            }
        }

        public static IEnumerable<KeyValuePair<TEnum, string>> GetDescriptions<TEnum>() where TEnum : struct, IConvertible
        {
            var values = GetValues<TEnum>();
            List<KeyValuePair<TEnum, string>> descriptions = new List<KeyValuePair<TEnum, string>>();

            foreach (var value in values)
            {
                descriptions.Add(new KeyValuePair<TEnum, string>(value, (value as Enum).GetDescription()));
            }

            return descriptions;
        }

        public static TEnum GetDefaultValue<TEnum>() where TEnum : struct
        {
            Type t = typeof(TEnum);
            DefaultValueAttribute[] attributes = (DefaultValueAttribute[])t.GetCustomAttributes(typeof(DefaultValueAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                return (TEnum)attributes[0].Value;
            }
            else
            {
                return (TEnum)Enum.GetValues(typeof(TEnum)).GetValue(0);
            }
        }

        public static IEnumerable<string> GetNames<TEnum>() where TEnum : struct, IConvertible
        {
            return GetNames(typeof(TEnum));
        }

        public static IEnumerable<string> GetNames(Type type)
        {
            AssertEnum(type);

            return from fi in type.GetFields(BindingFlags.Public | BindingFlags.Static)
                   where fi.IsLiteral
                   select fi.Name;
        }

        public static IEnumerable<string> GetDisplayNames<TEnum>() where TEnum : struct, IConvertible
        {
            AssertEnum(typeof(TEnum));

            return from fi in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static)
                   let attribute = fi.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() as DisplayAttribute
                   where fi.IsLiteral
                   select attribute != null ? attribute.Name : fi.Name;
        }

        public static IEnumerable<TEnum> GetValues<TEnum>() where TEnum : struct, IConvertible
        {
            AssertEnum(typeof(TEnum));

            foreach (var item in Enum.GetValues(typeof(TEnum)).Cast<TEnum>())
            {
                yield return item;
            }
        }

        public static void AssertEnum(Type type)
        {
            if (!type.IsEnum)
                throw new ArgumentException(String.Format("Type '{0}' is not an enum."), type.Name);
        }
    }
}
