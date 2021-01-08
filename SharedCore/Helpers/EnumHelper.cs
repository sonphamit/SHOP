using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace SharedCore.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// get description of enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo != null)
            {
                if (fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute), false) is not DescriptionAttribute[] descriptionAttributes) return string.Empty;
                return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : value.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// get display name of enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDisplayName<T>(this T value)
        {
            return value.GetType()
                .GetMember(value.ToString())
                .FirstOrDefault()?
                .GetCustomAttribute<DisplayAttribute>(false)?
                .Name ??
                value.ToString();
        }

        /// <summary>
        /// get all description of enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<KeyValuePair<T, string>> GetEnumAndDescriptions<T>()
        {
            Type enumType = typeof(T);

            if (enumType.GetTypeInfo().BaseType != typeof(Enum))
            {
                throw new ArgumentException("T is not System.Enum");
            }

            var enumValList = new List<KeyValuePair<T, string>>();

            foreach (T e in Enum.GetValues(typeof(T)))
            {
                var fi = e.GetType().GetField(e.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                enumValList.Add(new KeyValuePair<T, string>(e, attributes.Length > 0 ? attributes[0].Description : e.ToString()));
            }

            return enumValList;
        }

        public static Dictionary<int, string> ToDictionary<TEnum>()
        where TEnum : struct, IConvertible
        {
            return Enum.GetValues(typeof(TEnum))
            .Cast<int>()
            .ToDictionary(e => e, e => Enum.GetName(typeof(TEnum), e));
        }

        /// <summary>
        /// get all value and description of enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<KeyValuePair<string, string>> GetEnumStringAndDescriptions<T>()
        {
            Type enumType = typeof(T);

            if (enumType.GetTypeInfo().BaseType != typeof(Enum))
            {
                throw new ArgumentException("T is not System.Enum");
            }

            var enumValList = new List<KeyValuePair<string, string>>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                var fi = e.GetType().GetField(e.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                enumValList.Add(new KeyValuePair<string, string>(e.ToString(), attributes.Length > 0 ? attributes[0].Description : e.ToString()));
            }

            return enumValList;
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
