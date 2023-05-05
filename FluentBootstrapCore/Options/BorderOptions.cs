using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using System.Collections.Generic;

namespace FluentBootstrapCore.Options
{
    public class BorderOptions : UtilityOptions
    {
        public Border? Border { get; set; }
        public BorderColor? BorderColor { get; set; }
        public BorderRadius? BorderRadius { get; set; }
        public byte? Opacity { get; set; }

        public override IEnumerable<string> GetCssList()
        {
            var cssList = new List<string>();
            if (Border.HasValue)
                cssList.Add(Border.GetCssDescription());
            if (BorderColor.HasValue)
                cssList.Add(BorderColor.GetCssDescription());
            if (BorderRadius.HasValue)
                cssList.Add(BorderRadius.GetCssDescription());
            if (Opacity.HasValue)
                cssList.Add($"border-opacity-{Opacity}");
            return cssList;
        }
    }
}
