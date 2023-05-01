using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using System.Collections.Generic;

namespace FluentBootstrapCore.Options
{
    public class DisplayOptions : UtilityOptions
    {
        public EnumList<Display> Display { get; set; }
        public DisplayPrint? DisplayPrint { get; set; }
        public DisplayOptions()
        {
            Display = new EnumList<Display>();
        }

        public override IEnumerable<string> GetCssList()
        {
            var cssList = new List<string>();
            cssList.AddRange(Display.GetCssDescriptions());
            //foreach (var item in Display)
            //{
            //    cssList.Add(string.Format(item.Value.GetCssDescription(), item.Key.GetHyphenatedDescription()));
            //}
            if (DisplayPrint.HasValue)
                cssList.Add(DisplayPrint.GetCssDescription());
            return cssList;
        }
    }
}