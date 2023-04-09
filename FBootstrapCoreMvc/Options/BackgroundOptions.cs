using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Options
{
    public class BackgroundOptions : UtilityOptions
    {
        public BgColor? BgColor { get; set; }
        public bool Gradient { get; set; }
        public byte? Opacity { get; set; }

        public override IEnumerable<string> GetCssList()
        {
            var cssList = new List<string>();
            if (BgColor.HasValue)
                cssList.Add(BgColor.GetCssDescription());
            if (Gradient)
                cssList.Add(Css.BgGradient);
            if (Opacity.HasValue)
                cssList.Add($"bg-opacity-{Opacity}");
            return cssList;
        }
    }
}