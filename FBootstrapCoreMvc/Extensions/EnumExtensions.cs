using FBootstrapCoreMvc.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace FBootstrapCoreMvc.Extensions
{
    internal static class EnumExtensions
    {
        internal static string GetCssDescription(this Enum value)
        {
            var flagAttr = value.GetType().GetCustomAttribute<FlagsAttribute>();
            if (flagAttr != null)
            {
                var items = new List<string>();
                foreach (Enum enumVal in Enum.GetValues(value.GetType()))
                {
                    var description = enumVal.GetDescription();
                    if (value.HasFlag(enumVal) && !string.IsNullOrWhiteSpace(description))
                        items.Add(description);
                }
                return string.Join(" ", items);
            }

            return value.GetDescription();
        }

        internal static string GetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attribute = fi.GetCustomAttribute<DescriptionAttribute>();

            if (attribute != null)
                return attribute.Description;

            return value.ToString();
        }

        internal static string GetSuffix(this ComponentSize size) 
        {
            switch (size)
            {
                case ComponentSize.ExtraSmall:
                    return "sm";
                case ComponentSize.Small:
                    return "sm";
                case ComponentSize.Normal:
                    return "";
                case ComponentSize.Large:
                    return "lg";
                default:
                    return "";
            }
        }

        internal static string GetHyphenatedDescription(this Breakpoint breakpoint) 
        {
            var desc = breakpoint.GetCssDescription();
            if (string.IsNullOrWhiteSpace(desc))
                return desc;
            return $"-{desc}";
        }
    }
}
