using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Options
{
    public class FloatOptions : UtilityOptions
    {
        public Dictionary<Breakpoint, Float> Float { get; set; }

        public FloatOptions()
        {
            Float = new Dictionary<Breakpoint, Float>();
        }

        public override IEnumerable<string> GetCssList()
        {
            var cssList = new List<string>();
            foreach (var item in Float)
            {
                cssList.Add(string.Format(item.Value.GetCssDescription(), item.Key.GetHyphenatedDescription()));
            }
            return cssList;
        }
    }
}