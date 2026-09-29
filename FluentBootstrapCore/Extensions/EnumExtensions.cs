using FluentBootstrapCore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace FluentBootstrapCore.Extensions
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

            var attribute = fi?.GetCustomAttribute<DescriptionAttribute>();

            return attribute != null ? attribute.Description : value.ToString();
        }

        internal static string GetSuffix(this ComponentSize size)
        {
            return size switch
            {
                ComponentSize.ExtraSmall => "sm",
                ComponentSize.Small => "sm",
                ComponentSize.Normal => "",
                ComponentSize.Large => "lg",
                _ => "",
            };
        }

        internal static string GetHyphenatedDescription(this Breakpoint breakpoint)
        {
            var desc = breakpoint.GetCssDescription();
            return string.IsNullOrWhiteSpace(desc) ? desc : $"-{desc}";
        }
    }
}
