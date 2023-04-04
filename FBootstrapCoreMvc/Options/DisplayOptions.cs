using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Options
{
    public class DisplayOptions : UtilityOptions
    {
        public Dictionary<Breakpoint, Display> Display { get; set; }
        public DisplayPrint? DisplayPrint { get; set; }
        public DisplayOptions()
        {
            Display = new Dictionary<Breakpoint, Display>();
        }

        public override IEnumerable<string> GetCssList()
        {
            var cssList = new List<string>();
            foreach (var item in Display)
            {
                cssList.Add(string.Format(item.Value.GetCssDescription(), item.Key.GetHyphenatedDescription()));
            }
            if (DisplayPrint.HasValue)
                cssList.Add(DisplayPrint.GetCssDescription());
            return cssList;
        }
    }
}