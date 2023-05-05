using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using System.Collections.Generic;

namespace FluentBootstrapCore.Options
{
    public class ColorOptions : UtilityOptions
    {
        public TextColor? TextColor { get; set; }
        public byte? Opacity { get; set; }

        public override IEnumerable<string> GetCssList()
        {
            var cssList = new List<string>();
            if (TextColor.HasValue)
                cssList.Add(TextColor.GetCssDescription());
            if (Opacity.HasValue)
                cssList.Add($"text-opacity-{Opacity}");
            return cssList;
        }
    }
}