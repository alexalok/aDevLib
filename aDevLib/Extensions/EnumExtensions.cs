using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace aDevLib.Extensions
{
    [Obfuscation(Exclude = true, ApplyToMembers = true)]
    public static class EnumExtensions
    {
        public static bool Has<T>(this Enum type, T value) where T : Enum
        {
            try
            {
                return ((int) (object) type & (int) (object) value) == (int) (object) value;
            }
            catch
            {
                return false;
            }
        }

        public static bool Is<T>(this Enum type, T value) where T : Enum
        {
            try
            {
                return (int) (object) type == (int) (object) value;
            }
            catch
            {
                return false;
            }
        }


        public static T Add<T>(this Enum type, T value) where T : Enum
        {
            try
            {
                return (T) (object) ((int) (object) type | (int) (object) value);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    $"Could not append value from enumerated type '{typeof(T).Name}'.", ex);
            }
        }


        public static T Remove<T>(this Enum type, T value) where T : Enum
        {
            try
            {
                return (T) (object) ((int) (object) type & ~(int) (object) value);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    $"Could not remove value from enumerated type '{typeof(T).Name}'.", ex);
            }
        }

        public static string GetDescription(this Enum enumMember)
        {
            return enumMember.GetType().GetMember(enumMember.ToString()).First().GetCustomAttribute<DescriptionAttribute>().Description;
        }

        public static IEnumerable<T> GetFlags<T>(this T type) where T : Enum
        {
            return type.GetType().GetEnumValues().Cast<T>().Where(v => type.HasFlag(v));
        }

        public static string GetFullName(this Enum myEnum)
        {
            return $"{myEnum.GetType().Name}.{myEnum.ToString()}";
        }
    }
}