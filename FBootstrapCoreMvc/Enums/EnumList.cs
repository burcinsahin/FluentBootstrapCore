using FBootstrapCoreMvc.Extensions;
using System;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Enums
{
    public class EnumList<TEnum> : Dictionary<Breakpoint, TEnum>
        where TEnum : Enum
    {
        public EnumList() { }

        public IEnumerable<string> GetCssDescriptions()
        {
            foreach (var item in this)
            {
                yield return string.Format(item.Value.GetCssDescription(), item.Key.GetHyphenatedDescription());
            }
        }
    }
}