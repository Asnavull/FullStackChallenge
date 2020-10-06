using System;
using System.ComponentModel;
using System.Linq;

namespace FullStackChallenge.Util
{
    public static class UtilEnum
    {
        public static T GetAttributeFrom<T>(this Enum option) where T : Attribute
        {
            var member = option.GetType().GetMember(option.ToString()).FirstOrDefault();

            if (member != null)
                return (T)member.GetCustomAttributes(typeof(T), false).FirstOrDefault();
            else
                return null;
        }

        public static string GetDescription(this Enum option)
        {
            var attribute = option.GetAttributeFrom<DescriptionAttribute>();

            if (attribute != null)
                return attribute.Description;
            else
                return string.Empty;
        }

        public static T GetDefaultValue<T>(this Enum option)
        {
            try
            {
                return (T)option.GetAttributeFrom<DefaultValueAttribute>().Value;
            }
            catch
            {
                return default;
            }
        }

        public static T ParseStringToEnum<T>(string stringToParse, bool ignoreCase = true) where T : Enum
        {
            try
            {
                return (T)Enum.Parse(typeof(T), stringToParse, ignoreCase);
            }
            catch
            {
                return default;
            }
        }
    }
}